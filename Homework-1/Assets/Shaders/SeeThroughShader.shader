Shader "Custom/SeeThroughShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_SecondTex("Texture", 2D) = "white" {}
		_Zoom("Zoom", Range(0, 10)) = 5
		_BaseTransparency("BaseTransparency", Range(0, 1)) = 0.2
        _Color("Color", Color) = (0.5, 0.5, 0.5)
	}
	SubShader
	{
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
		
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
                float4 screenPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            sampler2D _SecondTex;
            float4 _MainTex_ST;
            float _Zoom;
            float _BaseTransparency;
            float4 _Color;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.screenPos = ComputeScreenPos(o.vertex);

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 screenPosition = (i.screenPos.xy / i.screenPos.w);
                screenPosition.y = screenPosition.y / (_ScreenParams.x / _ScreenParams.y);

                float2 sampleCoords = screenPosition;
                sampleCoords.x = 0.5 + (screenPosition.x - 0.5) / _Zoom;
                sampleCoords.y = 0.5 + (screenPosition.y - 0.5) / _Zoom;

                float4 col = tex2D(_SecondTex, sampleCoords);
                col.xyz = tex2D(_MainTex, i.uv).xyz;
                col.xyz *= _Color;
                col.w += _BaseTransparency;
                col = saturate(col);
                return col;
            }
            ENDCG
		}
	}
}
