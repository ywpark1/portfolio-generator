# Portfolio Generator

This is a resume/portfolio html file generator.

## Getting Started

This project is using C# and .NET Core framework with CLI tools.

### Prerequisites

[Windows Prerequisites](https://docs.microsoft.com/en-us/dotnet/core/windows-prerequisites?tabs=netcore21)

[macOS Prerequisites](https://docs.microsoft.com/en-us/dotnet/core/macos-prerequisites?tabs=netcore2x)

[Linux Prerequisites](https://docs.microsoft.com/en-us/dotnet/core/linux-prerequisites?tabs=netcore2x)

### Installing
To check whether the dotnet CLI is installed on your machine, run :

```bash
dotnet
or
dotnet --info
```

For further information on dotnet CLI installation go to the following website:

https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x


### How-To-Use

1. Move to the root directory of this project (portfolio-generator), and run the following :

```bash
dotnet run --project ./Portfolio-generator-console/Portfolio-generator-console.csproj
```

2. The generated html file (index.html) is stored under 'portfolio' directory.

Currently, 'name' can be changed in the template.

**NOTE** : It is continuously updating.

### Upload to Repository ([USER_NAME.github.io])

1. Create new repository with the name 'USER_NAME.github.io'. (\*)

2. Copy the repository URL (ex. https://github.com/USER_NAME/USER_NAME.github.io.git). (\*)

3. In the Command Line, move to the root directory of this project(portfolio-generator).

4. Run the following commands :

```bash
./portfolio-uploader.sh
```

5. Enter the repository URL you copied.

6. Enter the github username and password to upload files to repository.
   ⋅⋅\* If it displays an error, check your repository URL.

(\*) : Replace the USER_NAME with your github account username.

**NOTE** : It is working with empty repository only.

### Template Fields

- {YOUR_NAME}

**NOTE** : It is continuously updating.

## TODOs

- [ ] Support GUI version
- [ ] Read Word file and get contents
- [ ] Add more templates

## Contributing
Please read CONTRIBUTING.md for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning
For the versions available, see the tags on this repository.

## Authors
See also the list of contributors who participated in this project.
-Name1
-Name2 .. 
## Acknowledgments
-Give credit to websites/code used online
-Inspiration
