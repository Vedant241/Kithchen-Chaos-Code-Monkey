using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour {

    [SerializeField] private KitchenObjectsSO KitchenObjectsSO;

    private IKitchenObjectParents kitchenObjectParent;

    public KitchenObjectsSO GetKitchenObjectsSO() { return KitchenObjectsSO; }

    public void SetKitchenObjectParent(IKitchenObjectParents kitchenObjectParent) {
        if (this.kitchenObjectParent != null) {
            this.kitchenObjectParent.ClearKitchenObject();
        }

        this.kitchenObjectParent = kitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject()) {
            Debug.LogError("KitchenObjectParent already has a KitchenObject");
        }

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParents GetKitchenObjectParent() {
        return kitchenObjectParent;
    }

    public void DestroyItself() {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject) {
        if(this is PlateKitchenObject) {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        } else {
            plateKitchenObject = null;
            return false;
        }
    }


    public static KitchenObject SpawnKitchenObject(KitchenObjectsSO kitchenObjectsSO,IKitchenObjectParents kitchenObjectParents) {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab);

        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        
        kitchenObject.SetKitchenObjectParent(kitchenObjectParents);

        return kitchenObject;
    }
}