using UnityEngine;

public class CubeCut : MonoBehaviour
{
    public static bool Cut(Transform cutObject, Vector3 _pos)
    {
        Vector3 pos = new Vector3(_pos.x, cutObject.position.y, cutObject.position.z);
        Vector3 cutObjectScale = cutObject.localScale;
        float distance = Vector3.Distance(cutObject.position, pos);
        if (distance >= cutObjectScale.x / 2) return false;

        Vector3 leftPoint = cutObject.position - Vector3.right * cutObjectScale.x / 2;
        Vector3 rightPoint = cutObject.position + Vector3.right * cutObjectScale.x / 2;
        Mesh originalObject = cutObject.GetComponent<MeshFilter>().mesh;
        Mesh originalSkinnedMesh = cutObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        Material mat = cutObject.GetComponent<SkinnedMeshRenderer>().material;
        Destroy(cutObject.gameObject);

        GameObject rightSideObj = new GameObject(cutObject.name);
        rightSideObj.transform.position = (rightPoint + pos) / 2;
        float rightWidth = Vector3.Distance(pos, rightPoint);
        rightSideObj.transform.localScale = new Vector3(rightWidth, cutObjectScale.y, cutObjectScale.z);
        rightSideObj.AddComponent<MeshFilter>();
        rightSideObj.GetComponent<MeshFilter>().mesh = originalObject;
        rightSideObj.AddComponent<SkinnedMeshRenderer>();
        rightSideObj.GetComponent<SkinnedMeshRenderer>().sharedMesh = originalSkinnedMesh;
        rightSideObj.GetComponent<SkinnedMeshRenderer>().material = mat;
        rightSideObj.AddComponent<Cloth>();


        GameObject leftSideObj = new GameObject(cutObject.name);
        leftSideObj.transform.position = (leftPoint + pos) / 2;
        float leftWidth = Vector3.Distance(pos, leftPoint);
        leftSideObj.transform.localScale = new Vector3(leftWidth, cutObjectScale.y, cutObjectScale.z);
        leftSideObj.AddComponent<MeshFilter>();
        leftSideObj.GetComponent<MeshFilter>().mesh = originalObject;
        leftSideObj.AddComponent<SkinnedMeshRenderer>();
        leftSideObj.GetComponent<SkinnedMeshRenderer>().sharedMesh = originalSkinnedMesh;
        leftSideObj.GetComponent<SkinnedMeshRenderer>().material = mat;
        leftSideObj.AddComponent<Cloth>();

        return true;
    }
}