#version 330

in vec3 fColor;
in float fScale;
in vec2 fMouse;
in vec2 fResolution;

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

    //if(int(mColor.x) % 2 == 0 && int(mColor.y) % 2 == 0){
      //  resultColor = vec3(blackColor);
    //}
    //else if(int(mColor.x) % 2 != 0 && int(mColor.y) % 2 != 0){
      //  resultColor = vec3(blackColor);
    //} else{
      //  resultColor = vec3(whiteColor);
    //}
    return resultColor;
}

//vec3 pointLight(vec3 color){
//}

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

    //sColor = fColor;
    //vec2 uv = fColor.xz;

    //vec2 actualFragCoord = gl_FragCoord.xy / fResolution;
    //float d = distance(actualFragCoord, fMouse) * 5;
    //d = clamp(d, 0, 0.9);

    //uv = scaleAroundPoint(uv, fScale);

    // vec2 fragCoord = gl_FragCoord.xy;
    vec2 mouseOffset =  gl_FragCoord.xy - mousePos;
    float distance = sqrt((mouseOffset.x * mouseOffset.x) + (mouseOffset.y * mouseOffset.y));
    distance = clamp(distance / 300.f, 0, 1.0f);

    //float maxDistance = length(fResolution);
    //float brightness = 1.0 - (distance / maxDistance);
    //brightness = clamp(brightness, 0.0, 1.0);
    //sColor = vec4(fColor,1);

    //vec4 tempColor = vec4(color, color, color, 1);
	//tempColor.xyz -= d;

    sColor = vec4(checkerdPattern(color),1);

    sColor.xyz -= distance;

}

