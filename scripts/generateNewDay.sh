#!/bin/sh

dotnet new console -n $2 -o $1-$2/src > /dev/null
dotnet new xunit -n $2.Tests -o $1-$2/tests > /dev/null
cd $1-$2/tests
dotnet add reference ../src/$2.csproj > /dev/null
cd ..
touch input.txt

[ -d $1-$2 ] && echo "New day created"
