# HandTrackingMedicalSim

In order to work for IOS make sure you have cocoapods installed and open the .workspace in Xcode to build. Make sure archetecture
is arm64 only. Add the security framework to linked frameworks, add libmanomotion.framework to embedded binaries, in build phases
add AssetsLibrary.framework to link binary with libraries, finally make sure your deployment target is at least 9.2.
