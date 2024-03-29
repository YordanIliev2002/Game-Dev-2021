Shader "Custom/VignetteShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Intensity("Intensity", Range(0.0, 0.3)) = 0.1 
        _RadiusMin("RadiusMin", Range(0.0, 1)) = 0.2 
        _RadiusMax("RadiusMax", Range(0.0, 1)) = 0.5 
    }
    SubShader
    {

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Intensity;
            float _RadiusMin;
            float _RadiusMax;

            fixed4 frag(v2f i) : SV_Target
            {
                float normalizedWave = (sin(_Time.w) + 1) / 2; // [0, 1]
                float radius = lerp(_RadiusMin, _RadiusMax, normalizedWave); // [Rmin,Rmax]
                float dist = distance(i.uv.xy, float2(0.5, 0.5)); // [0, 1/sqrt(2)]
                float GBmult = (1-_Intensity) * (1 - smoothstep(radius, 1, dist));
                float4 filter = float4(1, GBmult, GBmult, 1);
                float4 col = tex2D(_MainTex, i.uv);
                return col * filter;
            }
            ENDCG
        }
    }
}
