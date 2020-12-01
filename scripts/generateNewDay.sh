#!/bin/sh

if [ "$#" -ne 1 ]; then
  echo "Name of the day required" >&2
  exit 1
fi

dotnet new console -n $1 -o $1 > /dev/null

[ -d $1 ] && echo "New day created"
