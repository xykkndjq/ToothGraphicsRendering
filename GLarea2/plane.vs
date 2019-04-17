attribute highp vec3 aPos;
attribute highp vec3 aNormal;

varying highp vec3 FragPos;
varying highp vec3 Normal;
varying highp vec4 FragPosLightSpace;

uniform highp mat4 model;
uniform highp mat4 view;
uniform highp mat4 projection;
uniform highp mat4 lightSpaceMatrix;

void main()
{
    FragPos = vec3(model * vec4(aPos.xyz, 1.0));
    Normal = mat3(transpose(inverse(model))) * aNormal;   
	FragPosLightSpace = lightSpaceMatrix * vec4(FragPos, 1.0);
    gl_Position = projection * view * vec4(FragPos, 1.0);
}