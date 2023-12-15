#version 330

in vec3 fColor;
out vec4 sColor;

uniform vec3 blackColor;
uniform vec3 whiteColor;
uniform int rows;
uniform int columns;

vec3 checkerdPattern(vec3 color){

    vec3 mColor = color;
    mColor.x *= rows;
    mColor.y *= columns;
    vec3 resultColor;

    if(int(mColor.x) % 2 == 0 && int(mColor.y) % 2 == 0){
        resultColor = vec3(blackColor);
    }
    else if(int(mColor.x) % 2 != 0 && int(mColor.y) % 2 != 0){
        resultColor = vec3(blackColor);
    } else{
        resultColor = vec3(whiteColor);
    }
    return resultColor;
}

void main (void) {
    sColor = vec4(checkerdPattern(fColor),1);
}

