#!/bin/bash
# Use set -x to show commands being executed after variable expansion
# set -x # Uncomment this line to enable tracing

# Calculate UTC timestamp inMMDDHHMMSS format
BuildTimestamp=$(date -u +"%Y%m%d%H%M%S")

echo "Using Build Timestamp: $BuildTimestamp"

# ### ADD THIS LINE TO SEE THE COMMAND (alternative to set -x) ###
# echo "dotnet build MySolution.sln -c Debug /p:BuildTimestamp=\"$BuildTimestamp\" -bl"
# #######################################

# Call dotnet build, passing the timestamp as a property
dotnet build GreenLight.DX.sln -c Debug -property:BuildTimestamp="$BuildTimestamp" -bl

# Uncomment this line if you used set -x at the top
# set +x