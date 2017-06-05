Shader "Custom/CustomGuiShader_Surface" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows vertex:vert addshadow 
		#pragma target 3.0

    //Our graphics always has the following features
    #define GRAPHIC_RENDERER_VERTEX_UV_0
    #define GRAPHIC_RENDERER_VERTEX_NORMALS
    #define GRAPHIC_RENDERER_MOVEMENT_TRANSLATION
    #define GRAPHIC_RENDERER_BLEND_SHAPES

    #pragma shader_feature _ GRAPHIC_RENDERER_CYLINDRICAL GRAPHIC_RENDERER_SPHERICAL
    #include "Assets/LeapMotion/Modules/GraphicRenderer/Resources/BakedRenderer.cginc"
    #include "UnityCG.cginc"

    struct Input {
      float2 uv_MainTex;
      float4 hsvOffset;
    };

    DEFINE_FLOAT4_CHANNEL(_HsvOffset);
		sampler2D _MainTex;

		half _Glossiness;
		half _Metallic;

    void vert(inout appdata_graphic_baked v, out Input o) {
      UNITY_INITIALIZE_OUTPUT(Input, o);
      BEGIN_V2F(v);

      APPLY_BAKED_GRAPHICS_STANDARD(v, o);   

      o.hsvOffset = getChannel(_HsvOffset);
    }

    float3 hsv2rgb(float3 c) {
      float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
      float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
      return c.z * lerp(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
    }

		void surf (Input IN, inout SurfaceOutputStandard o) {
      float4 color = tex2D(_MainTex, IN.uv_MainTex);

      float3 hsv = color.rgb;
      hsv.x += IN.hsvOffset.x;
      hsv.yz *= 1.0 - color.a * (1.0 - IN.hsvOffset.yz);

      o.Albedo = hsv2rgb(hsv);
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
