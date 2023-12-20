#version 330

in vec3 vertex;
in vec3 color;
uniform vec2 offset;
uniform vec2 mousePos;
uniform vec2 resolution;
uniform float scaling;

out vec3 fColor;
out vec2 fResolution;
out vec2 fMouse;
out float fScale;


void main (void) {
    gl_Position = vec4(vertex,1) + vec4(offset,0,0);
    fColor = color;
    fMouse = mousePos;
    fResolution = resolution;
    fScale = scaling;
}


