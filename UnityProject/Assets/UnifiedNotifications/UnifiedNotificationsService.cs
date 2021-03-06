﻿using System;

namespace UnifiedNotifications
{
    public sealed class UnifiedNotificationsService
    {
        #region Public static API.
        public static ILocalNotification CreateLocalNotification()
        {
            if (manager != null)
                return manager.CreateLocalNotification();

            return null;
        }

        public static void ScheduleLocalNotification
            ( string id
            , DateTime when
            , ILocalNotification notification
            , bool cancelPrevious = false)
        {
            if (manager != null)
                manager.ScheduleLocalNotification(id, when, notification, cancelPrevious);
        }

        public static void PresentLocalNotificationNow
            ( string id
            , ILocalNotification notification)
        {
            if (manager != null)
                manager.PresentLocalNotificationNow(id, notification);
        }

        public static void CancelLocalNotification (string id, bool cancelPending = true, bool cancelShown = true)
        {
            if (manager != null)
                manager.CancelLocalNotification(id);
        }

        public static void ClearLocalNotifications (bool cancelPending = true, bool cancelShown = true)
        {
            if (manager != null)
                manager.ClearLocalNotifications();
        }
        #endregion

        #region Private static properties.
        static Private.INotificationsServiceManager manager
        {
            get
            {
                if (manager_ == null)
                {
                    manager_ = Private.NotificationsServiceManagerBase.Instantiate();
                }

                return manager_;
            }
        }
        #endregion

        #region Private static field.
        static Private.INotificationsServiceManager manager_ = null;
        #endregion
    }
}
