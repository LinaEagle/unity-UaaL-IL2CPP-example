# Failed to make it work with IL2CPP scripting backend.

Original [Issue](https://github.com/Unity-Technologies/uaal-example/issues/65) (now is fixed)

### Android. What have I changed? In a nutshell.

- migrated to AndroidX
- changed target SDK version to 30 and minimum to 26 (according to ARCore requirements)
- upgraded gradle version to 7
- played around specifying ndk, for Unity version `2020 LTS` I've chosen `ndk 19.0.5232133` because it works
- I've tried to use `2021 LTS`, but faced ndk incompatibility. I'll expolore this issue after making it work with ARFoundation 
- unityLibrary - build.gradle - remove `buildToolsVersion` line to supress warnings about sdk tools incompatibility