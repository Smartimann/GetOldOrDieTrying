// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Custom/FlatSurface" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		[Toggle(USE_VERTEX_COLOR)] _USE_VERTEX_COLOR("Use Vertex Colors", Int) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Flat fullforwardshadows
		#pragma shader_feature USE_VERTEX_COLOR

		fixed3 _gShadowColor;
		float _Nudge;
		half4 LightingFlat (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
			fixed4 c;
            c.rgb = s.Albedo * lerp(_gShadowColor, _LightColor0, atten);
	
            c.a = s.Alpha;
            return c;
        }

		#pragma target 2.0

		struct Input {
			float3 vertexColor : COLOR;
			float2 uv_MainTex;
		};

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			 UNITY_DEFINE_INSTANCED_PROP(fixed3, _Color)
#define _Color_arr Props
		UNITY_INSTANCING_BUFFER_END(Props)
		sampler2D _MainTex;
		void surf (Input IN, inout SurfaceOutput o) {
			
			o.Albedo = UNITY_ACCESS_INSTANCED_PROP(_Color_arr, _Color) * tex2D(_MainTex, IN.uv_MainTex);
			#ifdef USE_VERTEX_COLOR
				o.Albedo *= IN.vertexColor;
			#endif
			o.Alpha = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
