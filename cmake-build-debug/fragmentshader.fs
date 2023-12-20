#version 330

in vec3 fColor;
in float fScale;

out vec4 sColor;

uniform vec3 blackColor;
uniform vec3 whiteColor;
uniform int rows;
uniform int columns;
uniform vec2 mousePos;

vec3 checkerdPattern(vec3 color){

    vec3 mColor = color;
    if (mColor.x < 0) { mColor.x -= 1;}
    if (mColor.y < 0) { mColor.y += 1;}

    mColor.x *= rows;
    mColor.y *= columns;
    vec3 resultColor;

    if(int(mColor.x) % 2 == int(mColor.y) % 2){
    resultColor = vec3(blackColor);} else{
    resultColor = vec3(whiteColor);}

    return resultColor;
}

vec3 scaleAroundPoint(vec3 color, float scale) {

	//With out offset the scale happens from the lower left corner.
	vec3 offset = vec3(0.5, 0.5, 0);

	vec3 result = color - offset;
	result *= scale;
	result += offset;

	return result;
}

void main (void) {

    vec3 color = scaleAroundPoint(fColor, fScale);
    sColor = vec4(checkerdPattern(color),1);

    vec2 mouseOffset =  gl_FragCoord.xy - mousePos;
    float distance = sqrt((mouseOffset.x * mouseOffset.x) + (mouseOffset.y * mouseOffset.y));
    distance = clamp(distance / 300.f, 0, 1.0f);

    sColor.xyz -= distance;
}

