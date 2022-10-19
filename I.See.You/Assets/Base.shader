Shader "Custom/Base"
{
    Properties{
      _MainTex("Texture", 2D) = "white" {}
    _Colour("Color (RGBA", Color) = (1, 1, 1, 1)
    _OutColor("Outline Colour", Color) = (1, 1, 1, 1)
    }
        SubShader{
          Tags { "RenderType" = "Opaque" }
          CGPROGRAM
          #pragma surface surf Lambert
          #pragma surface surf Lambert fullforwardshadows
            //#pragma vertex vert
            //#pragma fragment frag
            #include "UnityCG.cginc"

          struct Input {
              //float2 uv_MainTex;
        float4 color: _Color;
          };

          //sampler2D _MainTex;
          //float4 _OutColor;

          void surf(Input IN, inout SurfaceOutput o) {
              //o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
              o.Albedo = 0.25;
              //o.Albedo = tex2D(_Color, IN.uv_Color).rgb;
          }
          ENDCG
    }
        Fallback "Diffuse"
}