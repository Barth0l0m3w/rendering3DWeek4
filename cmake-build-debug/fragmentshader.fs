#version 330

in vec3 fColor;
in float fScale;

out vec4 sColor;

uniform vec3 blackColor;
uniform vec3 whiteColor;
uniform int rows;
uniform int columns;
uniform vec2 fMouse;
uniform vec2 fResolution;;


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

//vec3 pointLight(vec3 color){
//}

vec2 scaleAroundPoint(vec2 uv, float scale) {
	//With out offset the scale happens from the lower left corner.
	vec2 offset = vec2(0.5, 0.5);

	vec2 result = uv - offset;
	result *= scale;
	result += offset;

	return result;
}

void main (void) {

    //sColor = fColor;
    //vec2 uv = fColor.xz;

    //vec2 actualFragCoord = gl_FragCoord.xy / fResolution;
    //float d = distance(actualFragCoord, fMouse) * 5;
    //d = clamp(d, 0, 0.9);

    //uv = scaleAroundPoint(uv, fScale);

    // vec2 fragCoord = gl_FragCoord.xy;
    //float mouseDistance = distance(fragCoord, mousePos);

    //float maxDistance = length(screenSize);
    //float brightness = 1.0 - (mouseDistance / maxDistance);
    //brightness = clamp(brightness, 0.0, 1.0);
    //sColor = vec4(fColor,1);

    //vec4 tempColor = vec4(color, color, color, 1);
	//tempColor.xyz -= d;

    sColor = vec4(checkerdPattern(fColor),1);

}

