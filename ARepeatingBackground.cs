using UnityEngine;

namespace RepeatingBackground
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    [ExecuteInEditMode]
    public abstract class ARepeatingBackground : MonoBehaviour
    {
        private MeshRenderer _renderer;
        private MeshFilter _filter;

        public Camera renderCamera;
        public Shader shader;

        private void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
            _filter = GetComponent<MeshFilter>();

            var quad = CreateQuad();
            _filter.mesh = quad;

            var material = new Material(shader);
            material.mainTexture = texture;

            _renderer.sharedMaterial = material;
        }

        protected abstract Texture2D texture { get; }

        protected abstract Vector2 textureUnitSize { get; }

        private void LateUpdate()
        {
            transform.localScale = new Vector3(
                renderCamera.orthographicSize * 2 * renderCamera.aspect,
                renderCamera.orthographicSize * 2,
                1);

            var newPosition = renderCamera.transform.position;
            newPosition.z = transform.position.z;
            transform.position = newPosition;

            var scale = transform.localScale;
            var size = textureUnitSize;
            var material = _renderer.sharedMaterial;

            material.mainTextureScale = new Vector2(scale.x / size.x, scale.y / size.y);

            material.mainTextureOffset = new Vector2(
                Mathf.Repeat(renderCamera.transform.position.x, size.x) / size.x,
                Mathf.Repeat(renderCamera.transform.position.y, size.y) / size.y);
        }

        private static Mesh CreateQuad()
        {
            var mesh = new Mesh();

            mesh.vertices = new Vector3[]
            {
                new Vector3(-0.5f, -0.5f, 0),
                new Vector3(-0.5f, 0.5f, 0),
                new Vector3(0.5f, 0.5f, 0),
                new Vector3(0.5f, -0.5f, 0)
            };

            mesh.uv = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(0, 1),
                new Vector2(1, 1),
                new Vector2(1, 0)
            };

            mesh.normals = new Vector3[]
            {
                new Vector3(0, 0, -1),
                new Vector3(0, 0, -1),
                new Vector3(0, 0, -1),
                new Vector3(0, 0, -1)
            };

            mesh.triangles = new int[]
            {
                0, 1, 2,
                0, 2, 3
            };

            return mesh;
        }

        protected virtual void OnValidate()
        {
            Start();
        }

        protected virtual void Reset()
        {
            if (shader == null)
            {
                shader = Shader.Find("Unlit/Transparent");
            }
            if (renderCamera == null)
            {
                renderCamera = Camera.main;
            }
        }
    }
}

