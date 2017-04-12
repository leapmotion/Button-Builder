Shader "Unlit/Custom Gui Shader" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

      //Our graphics always has the following features
      #define GRAPHIC_RENDERER_VERTEX_UV_0
      #define GRAPHIC_RENDERER_MOVEMENT_TRANSLATION
      #define GRAPHIC_RENDERER_BLEND_SHAPES

      #pragma shader_feature _ GRAPHIC_RENDERER_CYLINDRICAL GRAPHIC_RENDERER_SPHERICAL
      #include "Assets/LeapMotionModules/GraphicRenderer/Resources/BakedRenderer.cginc"
      #include "UnityCG.cginc"

			sampler2D _MainTex;

      DEFINE_FLOAT4_CHANNEL(_HsvOffset);

      struct v2f_custom {
        V2F_GRAPHICAL
        float3 hsvOffset : TEXCOORD1;
      };

      float3 hsv2rgb(float3 c) {
        float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
        float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
        return c.z * lerp(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
      }
			
      v2f_custom vert(appdata_graphic_baked v) {
        BEGIN_V2F(v);

        v2f_custom o;
        APPLY_BAKED_GRAPHICS(v, o);

        o.hsvOffset = getChannel(_HsvOffset);

        return o;
      }
			
			fixed4 frag (v2f_custom i) : SV_Target {
        float3 hsv = tex2D(_MainTex, i.uv0).rgb;
        hsv.x += i.hsvOffset.x;
        hsv.yz *= (i.hsvOffset.yz);

        return fixed4(hsv2rgb(hsv), 1);
			}
			ENDCG
		}
	}
}
