attribute highp vec3 aPos;

uniform highp mat4 lightSpaceMatrix;

void main()
{
    gl_Position = lightSpaceMatrix * vec4(aPos, 1.0);
}