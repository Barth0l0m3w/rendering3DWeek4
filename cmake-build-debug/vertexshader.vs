#version 330

in vec3 vertex;
in vec3 color;
uniform vec2 offset;
uniform float scaling;

out vec3 fColor;
out float fScale;


void main (void) {
    gl_Position = vec4(vertex,1) + vec4(offset,0,0);
    fColor = color;
    fScale = scaling;
}


