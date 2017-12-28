Shader "Cg shader with two passes using discard" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Factor("Heigh", Range(0,1)) = 0

	}
		SubShader{

			// first pass (is executed before the second pass)
			Pass{
			Cull Front // cull only front faces

			CGPROGRAM

	#pragma vertex vert  
	#pragma fragment frag 
		fixed4 _Color;
		half _Factor;
		struct vertexInput {
		float4 vertex : POSITION;
	};
	struct vertexOutput {
		float4 pos : SV_POSITION;
		float4 posInObjectCoords : TEXCOORD0;
	};

	vertexOutput vert(vertexInput input)
	{
		vertexOutput output;

		output.pos = UnityObjectToClipPos(input.vertex);
		output.posInObjectCoords = input.vertex;

		return output;
	}

	float4 frag(vertexOutput input) : COLOR
	{
		if (input.posInObjectCoords.y > _Factor-0.6)
		{
			discard; // drop the fragment if y coordinate > 0
		}
	fixed a = _Factor;
	_Color.g = cos(a);
	return _Color; // red
	}

		ENDCG
	}

		// second pass (is executed after the first pass)
		Pass{
		Cull Back // cull only back faces

		CGPROGRAM

#pragma vertex vert  
#pragma fragment frag 
		fixed4 _Color;
		half _Factor;
		struct vertexInput {
		float4 vertex : POSITION;
	};
	struct vertexOutput {
		float4 pos : SV_POSITION;
		float4 posInObjectCoords : TEXCOORD0;
	};

	vertexOutput vert(vertexInput input)
	{
		vertexOutput output;

		output.pos = UnityObjectToClipPos(input.vertex);
		output.posInObjectCoords = input.vertex;

		return output;
	}

	float4 frag(vertexOutput input) : COLOR
	{
		if (input.posInObjectCoords.y > _Factor - 0.6)
		{
			discard; // drop the fragment if y coordinate > 0
		}
	fixed a = _Factor;
	_Color.g = cos(a+0.1);
	return _Color; // green
	}

		ENDCG
	}
	}
}