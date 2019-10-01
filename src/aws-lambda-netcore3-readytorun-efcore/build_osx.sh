#!/bin/bash

#
# FOR TESTING BUILD, CAN'T USE DEPLOYMENT
# BECAUSE OSX BINARY NOT COMPLATIBLE FOR AWS LAMBDA
#

rm -f $(pwd)/bootstrap
rm -f $(pwd)/package.zip
dotnet publish -r osx-x64 -c Release
cp bin/Release/netcoreapp3.0/osx-x64/publish/aws-lambda-netcore3-readytorun bootstrap
zip package.zip bootstrap