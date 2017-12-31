// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "DepthFog"
{
	Properties
	{
		_FogIntensity("FogIntensity", Range( 0 , 1)) = 0
		_FogMaxIntensity("FogMaxIntensity", Range( 0 , 1)) = 0
		_Color0("Color 0", Color) = (0,0,0,0)
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_TextureIntensity("TextureIntensity", Float) = 0.1
		_TextureColor("TextureColor", Color) = (0.2655171,0.3823529,0.2305363,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#pragma target 3.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
			float4 screenPos;
		};

		uniform float _TextureIntensity;
		uniform float4 _TextureColor;
		uniform sampler2D _TextureSample0;
		uniform float4 _Color0;
		uniform sampler2D _CameraDepthTexture;
		uniform float _FogIntensity;
		uniform float _FogMaxIntensity;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_TexCoord17 = i.uv_texcoord * float2( 2,2 ) + float2( 0,0 );
			float2 panner18 = ( uv_TexCoord17 + 1.0 * _Time.y * float2( 0.01,0.01 ));
			o.Albedo = ( _TextureIntensity * _TextureColor * tex2D( _TextureSample0, panner18 ) ).rgb;
			o.Emission = _Color0.rgb;
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float eyeDepth2 = LinearEyeDepth(UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture,UNITY_PROJ_COORD(ase_screenPos))));
			float clampResult10 = clamp( ( abs( ( eyeDepth2 - ase_screenPos.w ) ) * _FogIntensity ) , 0.0 , _FogMaxIntensity );
			o.Alpha = clampResult10;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=14001
233;349;1133;500;691.4642;453.2867;1;True;True
Node;AmplifyShaderEditor.ScreenPosInputsNode;1;-739.4196,91.20316;Float;False;1;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ScreenDepthNode;2;-494.6375,22.60611;Float;False;0;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;17;-204.3956,-253.6995;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;2,2;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;3;-248.6375,169.6061;Float;False;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;18;120.5981,-267.2363;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0.01,0.01;False;1;FLOAT;1.0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;6;81.94914,460.4099;Float;False;Property;_FogIntensity;FogIntensity;0;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.AbsOpNode;8;44.36584,200.0286;Float;False;1;0;FLOAT;0.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;11;448.1139,414.9133;Float;False;Property;_FogMaxIntensity;FogMaxIntensity;1;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;14;343.6041,-212.8328;Float;True;Property;_TextureSample0;Texture Sample 0;3;0;Assets/Shaders/Texture/dissolve-guide - 副本.tga;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;16;318.55,-512.4232;Float;False;Property;_TextureIntensity;TextureIntensity;4;0;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;21;369.5134,-400.4054;Float;False;Property;_TextureColor;TextureColor;5;0;0.2655171,0.3823529,0.2305363,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;416.7902,230.9927;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;13;525.604,42.16727;Float;False;Property;_Color0;Color 0;2;0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;10;752.0981,262.3724;Float;False;3;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;15;682.7136,-401.7418;Float;False;3;3;0;FLOAT;0,0,0,0;False;1;COLOR;0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;974.1369,-18.39045;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;DepthFog;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;Back;0;0;False;0;0;Transparent;0.5;True;False;0;False;Transparent;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;False;2;SrcAlpha;OneMinusSrcAlpha;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;FLOAT;0.0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;2;0;1;0
WireConnection;3;0;2;0
WireConnection;3;1;1;4
WireConnection;18;0;17;0
WireConnection;8;0;3;0
WireConnection;14;1;18;0
WireConnection;5;0;8;0
WireConnection;5;1;6;0
WireConnection;10;0;5;0
WireConnection;10;2;11;0
WireConnection;15;0;16;0
WireConnection;15;1;21;0
WireConnection;15;2;14;0
WireConnection;0;0;15;0
WireConnection;0;2;13;0
WireConnection;0;9;10;0
ASEEND*/
//CHKSM=09261F84BBEDB85169672DBB526A49339A0BCF53