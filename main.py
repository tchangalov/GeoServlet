import glob
import datetime
import csv
from collections import OrderedDict
import sys
from time import strftime, localtime
import arcpy, sys, csv
import os
from os import listdir
from os.path import isfile, join


def getData(frequency, count):
    time_slices = []
    begin_time = datetime.datetime.now()
    timeData = OrderedDict()
    keys = []
    for i in range(1, count + 1):
        time = datetime.datetime.now() - datetime.timedelta(hours=frequency * i)
        time_slices.append(time)
        timeData[time] = []

    for file in glob.glob("*.csv"):
        if "random" in file:
            with open(file, 'r') as f:
                reader = csv.reader(f)
                rowcount = 0
                for row in reader:
                    if rowcount != 0:

                        # startDate = row[7]
                        # startTime = row[8]

                        modDate = row[9]
                        modTime = row[10]

                        # endDate = row[11]
                        # endTime = row[12]
                        # sd = startDate + " " + startTime
                        # ed = endDate + " " + endTime
                        md = modDate + " " + modTime
                        try:
                            modDateTime = datetime.datetime.strptime(md, "%Y:%m:%d %H:%M:%S")
                        except Exception as e:
                            print("Exception")
                        for i in range(len(time_slices)):
                            if i == 0:
                                nexttime = begin_time
                            else:
                                nexttime = time_slices[i - 1]
                            time_slice = time_slices[i]
                            # if ((startDateTime>=time_slice and endDateTime<= nexttime) or (startDateTime<time_slice and endDateTime >time_slice)):
                            if (modDateTime >= time_slice and modDateTime <= nexttime):
                                timeData[time_slice].append(row)

                    else:
                        keys = row
                        rowcount += 1

    return timeData, keys, begin_time


if __name__ == '__main__':
    timeData, keys, begin_time = getData(float(sys.argv[1]), 10)
    keyset = timeData.keys()
    items = list(timeData.items())
    inTables = []
    count = 0
    for j in range(len(items)):
        if (len(items[j][1])) > 0:
            key = items[j][0]
            print(str(key))
            startTime = str(key).split(" ")[1].split(":")
            startTime = startTime[0] + startTime[1]
            startYearDate = str(key).split(" ")[0].split("-")
            startYearDate = startYearDate[0] + startYearDate[1] + startYearDate[2]
            if (count == 0):
                count += 1
                endTime = str(begin_time).split(" ")[1].split(":")
                endTime = endTime[0] + endTime[1]
            else:
                endTime = str(items[j - 1][0]).split(" ")[1].split(":")
                endTime = endTime[0] + endTime[1]

            filename = "timeSlice_" + startTime + "_" + endTime + "_" + startYearDate + ".csv"
            inTables.append(filename)

            with open(filename, "w") as output_file:
                data2 = []
                for entry in timeData[key]:
                    data = {}
                    for i in range(len(entry)):
                        data[keys[i]] = entry[i]
                    data2.append(data)
                dict_writer = csv.DictWriter(output_file, fieldnames=keys)
                dict_writer.writeheader()
                dict_writer.writerows(data2)

                output_file.close()


                # define paths
    myPath = "C:\\Users\\ivel9171\\Documents\\ArcGIS\\Projects\\MyProject\\GeoServlet"
    eventLayer = "pointShp"  # intermediate variable
    # pointLayer = r"C:/testdata/pointShp.lyr"
    pointGdbPath = "C:\\Users\\ivel9171\\Documents\\ArcGIS\\Projects\\MyProject\\GeoServlet\\incidentDensity.gdb"
    RasterGdbName = "RasterTimeSlices.gdb"

    # set up environment
    arcpy.env.workspace = myPath

    if arcpy.Exists(RasterGdbName):

        pass
    else:
        arcpy.CreateFileGDB_management(myPath, RasterGdbName)

    # sign in to get license
    token = arcpy.GetSigninToken()
    if token is not None:
        print(token['token'])

    arcpy.CheckOutExtension('Spatial')

    
    # for every .csv in the list, run it through event layer, copy feature to shapefile, and turn to point density raster.
    # .shp and raster file names share the same timestamp with .csv
    rasterFileList = []
    for csv in inTables:
        # delete any in previous data in memory
        arcpy.Delete_management(eventLayer)
    
        inTable = csv  # 'pointLayer'+csv[8:len(csv)-4]
        pointShp = pointGdbPath + '\\pointShp' + csv[9:len(csv) - 4]
        outRasName = 'ras' + csv[9:len(csv) - 4]
        y_coords = "YCoordinates"
        x_coords = "XCoordinates"
        print(csv)
    
        arcpy.MakeXYEventLayer_management(inTable, x_coords, y_coords, eventLayer,
                                          "GEOGCS['GCS_WGS_1984',DATUM['D_WGS_1984',SPHEROID['WGS_1984',6378137.0,298.257223563]],PRIMEM['Greenwich',0.0],UNIT['Degree',0.0174532925199433]];-400 -400 1000000000;-100000 10000;-100000 10000;8.98315284119521E-09;0.001;0.001;IsHighPrecision",
                                          None)
        try:
            # copy temporary event layer to a shapefile
            arcpy.CopyFeatures_management(eventLayer, pointShp)
            print("success")
        except:
            pass
        
        #arcpy.env.extent = "MAXOF"

        #arcpy.env.extent = arcpy.Extent(37.911868, 37.211868, -122.476862, -122.076862)
        print("extent set")			

        '''@Jasmine: edit the Point Density tool parameters here'''
        outRas = arcpy.sa.PointDensity(pointShp, "None", 0.025, "Circle 0.025 MAP", "SQUARE_MAP_UNITS")
        try:
            print("saving")

            outRas.save(myPath + "\\" + RasterGdbName + "\\" + outRasName)
        except:
            pass
        rasterFileList.append(myPath + "\\" + RasterGdbName + "\\" + outRasName)
        print("Generated raster layer for", csv)
    arcpy.CheckInExtension('Spatial')
    
    myPath.replace("\\", "/")
    print(rasterFileList)
    mosaicGDBPath = myPath + "/compiledMosaic.gdb"
    mosaicGDB = "compiledMosaic.gdb"
    mosaicName = "temporalDensity" + strftime("%Y_%m_%d_%H_%M_%S", localtime())
    inRasGdb = "RasterTimeSlices.gdb"
    if arcpy.Exists(mosaicGDB):
        print("yes")
        # pass
    else:
        print("no")
        arcpy.CreateFileGDB_management(myPath, mosaicGDB)
    
    arcpy.management.CreateMosaicDataset(mosaicGDBPath, mosaicName,
                                         "PROJCS['WGS_1984_Web_Mercator_Auxiliary_Sphere',GEOGCS['GCS_WGS_1984',DATUM['D_WGS_1984',SPHEROID['WGS_1984',6378137.0,298.257223563]],PRIMEM['Greenwich',0.0],UNIT['Degree',0.0174532925199433]],PROJECTION['Mercator_Auxiliary_Sphere'],PARAMETER['False_Easting',0.0],PARAMETER['False_Northing',0.0],PARAMETER['Central_Meridian',0.0],PARAMETER['Standard_Parallel_1',0.0],PARAMETER['Auxiliary_Sphere_Type',0.0],UNIT['Meter',1.0]]",
                                         None, None, "NONE", None)
    
    # arcpy.management.AddRastersToMosaicDataset(r"C:\testdata\compiledMosaic.gdb\temporalDensity", "Raster Dataset", input)
    arcpy.management.AddRastersToMosaicDataset(myPath + "/compiledMosaic.gdb/" + mosaicName, "Raster Dataset",
                                               rasterFileList, "UPDATE_CELL_SIZES", "UPDATE_BOUNDARY", "NO_OVERVIEWS", None,
                                               0, 1500, None, None, "SUBFOLDERS", "ALLOW_DUPLICATES", "NO_PYRAMIDS",
                                               "CALCULATE_STATISTICS", "NO_THUMBNAILS", None, "NO_FORCE_SPATIAL_REFERENCE",
                                               "ESTIMATE_STATISTICS", None)
