# Interop Testing

Testing Interop in the CoreCLR repo follows other tests in the repo and utilizes a series of small EXE projects that exercise a specific feature.

Tests should "fail fast" - meaning that throwing an exception immediately is the preferred method for indicating a failure. The `Main` function in the EXE should follow these rules:

1) Arguments should not be used
1) Catch test failure exceptions - log messsages
1) Return a non-`100` value on failure
1) Return `100` on successful test pass

Example:

    static public int Main(string[] notUsed)
    {
        try
        {
            // Test scenario here
        }
        catch (Exception e)
        {
            Console.WriteLine($"Test Failure: {e.Message}");
            return 101;
        }

        return 100;
    }

## Assets

There should be no more than **1** project type per folder (i.e. a folder can contain a managed and native but no more than **1** of each).

Ancillary source assets for all tests should be located in `Interop/common` and can be easily added to all managed tests via the `Interop.settings.targets` file or native tests via `Interop.cmake`.

A common pattern for testing is using the `Assert` utilities found in the `CoreFX` repo. A copy of some of these utilities can be found at `Interop/common/Assertion.cs` and is included in all test projects by the `Interop.settings.targets` import. In order to use, add the following `using CoreFXTestLibrary;` in the relevant test file.

All test source files should include the following banner:

    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.
    // See the LICENSE file in the project root for more information.

### Managed

Managed tests should be designed to use the [SDK style project](https://docs.microsoft.com/en-us/dotnet/core/tools/csproj) system provided by [`dotnet-cli`](https://github.com/dotnet/cli). In addition to the using the SDK style project, all managed projects should include the following:

`<Import Project="$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildThisFileDirectory), Interop.settings.targets))\Interop.settings.targets" />`

The above import allows all managed projects to be maintained in a unified way.

### Native

Native test assets use [CMake](https://cmake.org/) and can leverage any of the product build assets. In addition to the use of CMake projects, all native projects should include the following:

`include ("${CLR_INTEROP_TEST_ROOT}/Interop.cmake")`

The above import allows all native projects to be maintained in a unified way.

Note that native assets should be written in a manner that is portable across multiple platforms  (i.e. Windows, MacOS, Linux).

## Testing Areas

Interop testing is divided into several areas.

### P/Invoke

The P/Invoke bucket represents tests that involve a [Platform Invoke](https://docs.microsoft.com/en-us/dotnet/standard/native-interop) scenario.

Testing P/Invoke has two aspects:

1) Marshaling types
    * Primitives
    * `Array`
    * Structure
    * Union
    * `String`
    * `Delegate`
1) `DllImportAttribute`
    * Attribute values
    * Search paths

### Marshal API

The Marshal API surface area testing is traditionally done via unit testing and far better suited in the [CoreFX](https://github.com/dotnet/corefx/tree/master/src/System.Runtime.InteropServices/tests) repo. Cases where testing the API surface area requires native tests assets will be performed in the [CoreCLR](https://github.com/dotnet/coreclr/tree/master/tests/src/Interop) repo.

## Common Task steps

### Adding new native project
1) Update `coreclr/tests/src/Interop/CMakeLists.txt` to include new test asset directory
1) Verify project builds by running `build-tests.cmd`/`build-tests.sh` from repo root.
    * Passing `skipmanaged` will build only the native tests - only works on Windows platform.

### Adding new managed project
1) The build system automatically discovers managed test projects
1) Verify project builds by running `build-tests.cmd`/`build-tests.sh` from repo root