Shader "Custom/DistortionShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DistortionX("DistortionX", Range(0.0, 0.05)) = 0.007
        _DistortionY("DistortionY", Range(0.0, 0.05)) = 0.007
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

            float _DistortionX;
            float _DistortionY;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                // Shake - o.uv += float2(_DistortionX * sin(_Time.w * 1.9), _DistortionY * sin(_Time.w * 1.4));
                float2 offset;
                offset.x = _DistortionX * sin(_Time.w * 1.9);
                offset.y = _DistortionY * sin(_Time.w * 1.4);
                o.uv *= float2(1, 1) + offset;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
