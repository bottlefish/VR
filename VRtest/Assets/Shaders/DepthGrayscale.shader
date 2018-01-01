// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/DepthGrayscale"
{
	Properties {
	   _MainTex ("", 2D) = "white" {} //this texture will have the rendered image before post-processing
	   _Factor("Factor", Range(0,1)) = 0.3
	}

	SubShader {
		Tags { "RenderType"="Opaque" }

		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _CameraDepthTexture;
			float3 _Center;
			float _Radius;
			float _Factor;

			struct v2f {
			   float4 pos : SV_POSITION;
			   float4 scrPos:TEXCOORD1;
			   float4 worldPos:TEXCOORD2;
			};

			//Vertex Shader
			v2f vert (appdata_base v){
			   v2f o;
			   o.pos = UnityObjectToClipPos (v.vertex);
			   o.scrPos=ComputeScreenPos(o.pos);
			   o.worldPos = mul(unity_ObjectToWorld,v.vertex);
			   //for some reason, the y position of the depth texture comes out inverted
			   //o.scrPos.y = 1 - o.scrPos.y;
			   return o;
			}

			sampler2D _MainTex; 

			//Fragment Shader
			half4 frag (v2f i) : COLOR{
			   float depthValue = Linear01Depth (tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos)).r);
				fixed4 orgColor = tex2Dproj(_MainTex, i.scrPos);
			   half4 depth;
			   //float d = distance(_Center, i.worldPos);
			  

			  // if (d > _Radius ) {
					depth.r =   orgColor.r + depthValue *_Factor;
				   depth.g =   orgColor.g  +  depthValue *_Factor;
				   depth.b =   orgColor.b  + depthValue *_Factor;
			   //}
				//else{
				//	depth.r = orgColor.r;
				//   depth.g =	orgColor.g;
				//   depth.b = orgColor.b;
				//} 
				

			   depth.a = 1;
			   return depth;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
