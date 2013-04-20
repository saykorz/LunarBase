<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LunarBase.WebApp.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LunarBase.SL</title>
    <style type="text/css">
        html, body {
        }

        body {
            padding: 0;
            margin: 0;
            background-color: red;
        }

        #silverlightControlHost {
            width: 100%;
            text-align: center;
        }
    </style>
    <script type="text/javascript" src="Silverlight.js"></script>
    <script src="js/SilverlightInit.js"></script>
    <link href="https://google-developers.appspot.com/maps/documentation/javascript/examples/default.css" rel="stylesheet" />
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script src="js/MapInit.js"></script>
    <style type="text/css">
        #container {
            width: 100px;
            height: 100px;
            position: relative;
        }

        #pnlSLHost {
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
        }

        #map-canvas {
            width: 100%;
            height: 100%;
            position: absolute;
            top: 0;
            left: 0;
        }

        #pnlSLHost {
            z-index: 99;
        }

        #map-canvas {
            z-index: 10;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function getRandomPosition() {
            // Place markers on map randomly.
            //var randX = Math.random();
            //var randY = Math.random();
            //randX *= (randX * 1000000) % 2 == 0 ? 1 : -1;
            //randY *= (randY * 1000000) % 2 == 0 ? 1 : -1;
            //var randLatLng = new google.maps.LatLng(
            //    center.lat() + (randX * 0.1),
            //    center.lng() + (randY * 0.1));

            var bounds = map.getBounds();
            var southWest = bounds.getSouthWest();
            var northEast = bounds.getNorthEast();
            var lngSpan = northEast.lng() - southWest.lng();
            var latSpan = northEast.lat() - southWest.lat();
            var point = new google.maps.LatLng(southWest.lat() + latSpan * Math.random(),
                southWest.lng() + lngSpan * Math.random());
            placeMarker(point);

            return point.toString();
        }
        
        function placeMarker(location) {
            if (marker) {
                marker.setPosition(location);
            } else {
                marker = new google.maps.Marker({
                    position: location,
                    map: map
                });
            }
        }
    </script>
</head>
<body onload="initialize()">
    <div id="container"></div>
    <div id="pnlSLHost">
        <form id="form1" runat="server">
            <div id="silverlightControlHost">
                <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
                    <param name="source" value="ClientBin/LunarBase.SL.xap" />
                    <param name="onLoad" value="pluginLoaded" />
                    <param name="onError" value="onSilverlightError" />
                    <param name="background" value="white" />
                    <param name="minRuntimeVersion" value="5.0.61118.0" />
                    <param name="autoUpgrade" value="true" />
                    <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=5.0.61118.0" style="text-decoration: none">
                        <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight" style="border-style: none" />
                    </a>
                </object>
                <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>
            </div>
        </form>
    </div>
    <div id="map-canvas" style="width: 100%; height: 100%;"></div>
</body>
</html>
