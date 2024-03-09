# FiveM as a Service

This is a simple project for running your Fivem server as a Windows Service.

## Why would I want to do that?

Well, running your server as a service would mean that it all running in the
background, you would no longer have to be afraid of accidentally closing the
Terminal window running your server.

It would also allow for the server to automatically be started upon startup, and
automatically restarted if stopped, and so on.

## Quick start

1. **Building/Downloading the files**
  <br/>Either download the prebuilt binaries via our [releases page](https://github.com/Z3rio/fivem-as-service/releases)
  <br/>or, download the source and build the files yourself via `make build`

2. **Configure**
  <br/>Look through the `Server` section of the `appsettings.json` file and make sure it looks good

3. **Install**
  <br/>Either manually install the service via `sc`, or run the `installer.bat` file and it'll install everything for you.
