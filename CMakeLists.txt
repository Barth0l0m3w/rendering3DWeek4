cmake_minimum_required(VERSION 3.26)
project(rendering3DWeek4)

set(CMAKE_CXX_STANDARD 17)

add_executable(rendering3DWeek4 main.cpp
        ShaderUtil.cpp)


find_package(SFML COMPONENTS system window graphics CONFIG REQUIRED)
target_link_libraries(rendering3DWeek4 PRIVATE sfml-system sfml-network sfml-graphics sfml-window)
find_package(GLEW REQUIRED)
target_link_libraries(rendering3DWeek4 PRIVATE GLEW::glew)