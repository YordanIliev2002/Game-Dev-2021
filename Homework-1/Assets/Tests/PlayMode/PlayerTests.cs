using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;

public class PlayerTests
{
    [UnityTest]
    public IEnumerator PlayerShouldBounceOnSpring()
    {
        GameObject springPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Spring.prefab", typeof(Object)) as GameObject;
        GameObject spring = GameObject.Instantiate(springPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        GameObject playerPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Player.prefab", typeof(Object)) as GameObject;
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 4, 0), Quaternion.identity);
        Rigidbody2D playerBody = player.GetComponent<Rigidbody2D>();
        player.GetComponent<CharacterMovement>().enabled = false;


        for(int i = 0; i < 100; i++) // Over the next 100 fixedupdates
        {
            // If the player is going up, he must have bounced
            if(playerBody.velocity.y > 0)
            {
                Debug.Log(i);
                GameObject.Destroy(spring);
                GameObject.Destroy(player);
                Assert.Pass();
            }
            yield return new WaitForFixedUpdate();
        }

        // If he has not gone up
        GameObject.Destroy(spring);
        GameObject.Destroy(player);
        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator SpikesShouldHurtPlayer()
    {
        GameObject spikesPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Spikes.prefab", typeof(Object)) as GameObject;
        GameObject spikes = GameObject.Instantiate(spikesPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        GameObject playerPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Player.prefab", typeof(Object)) as GameObject;
        GameObject player = GameObject.Instantiate(playerPrefab, new Vector3(0, 4, 0), Quaternion.identity);

        bool wasHealthReduced = false;
        yield return new WaitForFixedUpdate();
        player.GetComponent<Respawnable>().onHealthChange += (health) => { if (health < 3) { wasHealthReduced = true; } };

        for (int i = 0; i < 100; i++) // Over the next 100 fixedupdates
        {
            if (wasHealthReduced)
            {
                GameObject.Destroy(spikes);
                GameObject.Destroy(player);
                Assert.Pass();
            }
            yield return new WaitForFixedUpdate();
        }

        GameObject.Destroy(spikes);
        GameObject.Destroy(player);
        Assert.Fail();
    }

}
