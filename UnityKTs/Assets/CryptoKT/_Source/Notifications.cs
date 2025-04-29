using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notifications : MonoBehaviour
{
    public static Notifications Instance;

    [SerializeField] private float removeNotificationTime = 1f;
    [SerializeField] private TMP_Text notificationLabel;

    private readonly List<string> _notifications = new();

    private void Awake() => Instance = this;

    public void SendNotification(string notification)
    {
        _notifications.Add(notification);
        RedrawNotifications();
        StartCoroutine(NotificationRemoveCoroutine());
    }

    private void RedrawNotifications()
    {
        var result = string.Join("\n\n", _notifications);
        notificationLabel.text = result;
    }

    private IEnumerator NotificationRemoveCoroutine()
    {
        yield return new WaitForSeconds(removeNotificationTime);

        _notifications.RemoveAt(0);
        RedrawNotifications();
    }
}