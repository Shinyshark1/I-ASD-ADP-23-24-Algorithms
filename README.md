# I-ASD-ADP-23-24-Algorithms
There are two projects:
1. Algorithm
2. Algorithms.Tests

## The Algorithms Project
The Algorithms project has a folder for each algorithm or data structure that has been implemented. Each folder contains:
1. An interface for the algorithm or data structure
2. The implementation of the interface
3. A folder called 'Benchmarks' with a class that strives to benchmark the various operations


## The Algorithms.Tests
The Algorithms.Tests project has unit tests for ease of development via test driven development.
Each algorithm or data structure has one unit test at the top that proves that the provided datasets can be read by the algorithm or data structure.

## Codespaces
[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)]([URL](https://codespaces.new/Shinyshark1/I-ASD-ADP-23-24-Algorithms/tree/main?quickstart=1)https://codespaces.new/Shinyshark1/I-ASD-ADP-23-24-Algorithms/tree/main?quickstart=1)

### Running tests
All tests can be found in Algorithms/Algorithms.Tests

Open the terminal:

![image](https://github.com/Shinyshark1/I-ASD-ADP-23-24-Algorithms/assets/54573990/1246d055-a903-43c2-be4b-98c5439669cb)


In the terminal navigate to the Algorithms folder with 'cd Algorithms' and type 'dotnet test' to run the tests. You should see something like this:

![image](https://github.com/Shinyshark1/I-ASD-ADP-23-24-Algorithms/assets/54573990/a05eb27d-dc83-4db6-9744-0985634e7b02)


### Running the benchmarks
All benchmarks can be found in the 'benchmark' folder inside of the folder for the algorithm or data structure.

In order to run the benchmarks go to the Algorithms/Program.cs and comment/uncomment your selection of benchmarks. In the console, make sure that you are in '/workspaces/I-ASD-ADP-23-24-Algorithms/Algorithms/Algorithms'. If you can see the .csproj file when you type 'ls', you are in the correct place. Type 'dotnet run' to run your desired benchmarks.

I have noticed that some of the benchmarks will not fully run; this is likely due to the strength of the codespace. I will try to provide images of my results so that you may view those as well.
