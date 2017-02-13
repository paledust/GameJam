// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/BasicShader" {
	Properties {
		_Color ("Filter Color", Color) = (1,1,1,1) 
	}
	SubShader {
		Tags { "Queue" = "Transparent" } 
			// draw after all opaque geometry has been drawn
		Pass {
			ZWrite Off // don't write to depth buffer 
				// in order not to occlude other objects

			Blend DstColor Zero // use alpha blending

			CGPROGRAM 
	
			#pragma vertex vert 
			#pragma fragment frag
			
			float4 _Color;

			float4 vert(float4 vertexPos : POSITION) : SV_POSITION 
			{
				return mul(UNITY_MATRIX_MVP, vertexPos);
			}
	
			float4 frag(void) : COLOR 
			{
				return _Color; 
				// the fourth component (alpha) is important: 
				// this is semitransparent green
			}
	
			ENDCG  
		}
	}
	}