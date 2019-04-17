varying highp vec3 FragPos;
varying highp vec3 Normal;

uniform highp vec3 color;
uniform highp float alpha;
uniform highp vec3 lightPos;
uniform highp vec3 viewPos;
uniform sampler2D shadowMap;
varying highp vec4 FragPosLightSpace;

float ShadowCalculation(vec4 fragPosLightSpace)
{
    // perform perspective divide
    vec3 projCoords = fragPosLightSpace.xyz / fragPosLightSpace.w;
    // transform to [0,1] range
    projCoords = projCoords * 0.5 + 0.5;
    // get closest depth value from light's perspective (using [0,1] range fragPosLight as coords)
    float closestDepth = texture(shadowMap, projCoords.xy).r; 
    // get depth of current fragment from light's perspective
    float currentDepth = projCoords.z;
    // check whether current frag pos is in shadow
    float shadow = currentDepth > closestDepth  ? 1.0 : 0.0;

    return shadow;
}
void main()
{     
    // ambient
    vec3 ambient = 0.2;  
	float shadow = ShadowCalculation(FragPosLightSpace); 
	//gl_FragColor = shadow * vec4(color, 1);
	//vec3 lighting = (ambient + (1.0 - shadow) * (diffuse + specular)) * color; 
	if(shadow == 1.0)
		color = ambient * color;
	gl_FragColor = vec4(color, 1.0);
}