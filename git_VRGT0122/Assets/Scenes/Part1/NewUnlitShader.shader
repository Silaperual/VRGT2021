// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Screencolors Adjuster"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _Brightness("Brightness", Float) = 1
        _Saturation("Saturation", Float) = 0
        _Contrast("Contrast", Float) = 0
    }

        SubShader
        {
            Pass
            {
                ZTest Always
                ZWrite Off
                Cull Off

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                sampler2D _MainTex;
                float _Brightness;
                float _Saturation;
                float _Contrast;

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;

                    return o;
                }

                fixed4 frag(v2f i) : SV_TARGET
                {
                    fixed4 tex = tex2D(_MainTex, i.uv);

                    fixed3 finalCol = tex.rgb * _Brightness;

                    fixed luminance = dot(fixed3(0.2125, 0.7154, 0.0721), tex.rgb);
                    fixed3 luminanceCol = fixed3(luminance, luminance, luminance);
                    finalCol = lerp(finalCol, luminanceCol, _Saturation);

                    fixed3 avgCol = fixed3(0.5, 0.5, 0.5);
                    finalCol = lerp(finalCol, avgCol, _Contrast);

                    return fixed4(finalCol, tex.a);
                }

                ENDCG
            }
        }

            Fallback Off
}