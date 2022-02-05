Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        m0 ("m0",Float) = 0
        m1 ("m1",Float) = 1
        m2 ("m2",Float) = 0
        m3 ("m3",Float) = 1
        m4 ("m4",Float) = 0
        m5 ("m5",Float) = 1
        m6 ("m6",Float) = 0
        m7 ("m7",Float) = 1

    }
    SubShader
    {
        Pass
        {
            Cull off
            //Blend  SrcAlpha OneMinusSrcAlpha
            //ZWrite Off
            ZWrite On

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                fixed4 vertex : POSITION;
                fixed2 uv : TEXCOORD0;
            };

            struct v2f
            {
                fixed2 uv : TEXCOORD0;
                fixed4 color: COLOR;
                fixed4 vertex : SV_POSITION;
                fixed fresnel : TEXCOORD1;
            };

            fixed m0;
            fixed m1;
            fixed m2;
            fixed m3;
            fixed m4;
            fixed m5;
            fixed m6;
            fixed m7;

            float4 uvToVertex(float2 uv) {

                fixed pi = 3.141592;
                fixed phi,theta;
                
                phi = uv.x  * pi;
                theta = uv.y * 2 *  pi;

                fixed r = 0;
                r += pow(abs(sin(m0*phi)),m1);
                r += pow(abs(cos(m2*phi)),m3);
                r += pow(abs(sin(m4*theta)),m5);
                r += pow(abs(cos(m6*theta)),m7);

                float x,y,z;
                
                x = r * sin(phi) * cos(theta);
                y = r * sin(phi) * sin(theta);
                z = r * cos(phi);

                return float4(x,y,z,1);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.uv = v.uv;// TRANSFORM_TEX(v.uv, _MainTex);

                float4 vertex = uvToVertex(v.uv);

                //fixed4 vertex = v.vertex;
                //vertex =  vertex* r;

                o.color = lerp(fixed4(0,.5,1,1)*.5, fixed4(0,1,.5,1)*.5,clamp(length(vertex*.35),0,1));
                o.vertex = UnityObjectToClipPos(vertex);

				fixed3 i = normalize(ObjSpaceViewDir(vertex));
				o.fresnel = dot(i, normalize(vertex)); //o.fresnel = o.fresnel * o.fresnel; 
                o.fresnel = o.fresnel * o.fresnel;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 c = i.color;//tex2D(_MainTex, i.uv);
                c -= (1-i.fresnel)*.25;
                return c;
            }
            ENDCG
        }
    }
}
