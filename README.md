# VL.Nuget.Template 

Quick start your VL nuget development with this bare-bones VL Nuget template.

Based on https://github.com/vvvv/VL.IO.OSC

This template is intended for projects with VL only, without C# solutions.

## Using the template

1. Press `Use this template` above to create a new repo based on this one (https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template)
2. `git clone` into the new repository
3. Rename the `.nuspec` file in deployment and edit its contents
4. Update reference to this file in `workflows/main.yml`
5. Update LICENSE copyright holder
6. Replace this README.md
7. Generate and set the NUGET_KEY github repo secret (see https://thegraybook.vvvv.org/reference/extending/publishing.html#getting-a-nugetorg-api-key)
8. Rename/replace the root patch and start working

**For more details on how to package VL Nugets, refer to the following page in the Gray Book:**

https://thegraybook.vvvv.org/reference/extending/publishing.html

## Contents

### VL Library files

*.vl files located in the root

### Help patches

Place help patches in the `help` folder

Start each filename with either `Explanation` or `HowTo`, depending on the purpose of the help patch.

For more information refer to https://thegraybook.vvvv.org/reference/extending/providing-help.html

### Deployment

Contains the `.nuspec` nuget definition file. This includes the nuget metadata (name, description, ...) and included files.
