# Migrated

Moved to: https://codeberg.org/newteq/sample-kafka-pub-sub

# Getting Started

> It is recommended to use a linux distro for running this code. You can do this on Windows 10 through the WSL (Windows Subsystem for Linux).

## Kafka

Follow this quick start guide on the [kafka website](https://kafka.apache.org/quickstart)

All you need to do, is download the binaries and start the server. **Do not create a topic or anything more from the quick start guide**

To easily run the commands as they are specified in the quick start guide, run them from within the WSL if you are on Windows.

## This sample program

1. Open Visual Studio
2. Run the `KafkaPub` application
3. Run the `KafkaSub` application

You should see output on both the applications.

# Clean up

To ensure that this runs smoothly next time, simply run `rm -rf /tmp/kafka-logs/` from the WSL
