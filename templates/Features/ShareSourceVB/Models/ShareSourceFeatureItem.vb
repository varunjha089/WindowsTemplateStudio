﻿Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports Windows.Storage

Namespace Models

    Friend Enum ShareSourceFeatureItemType
        Text = 0
        WebLink = 1
        ApplicationLink = 2
        Html = 3
        Image = 4
        StorageItems = 5
        DeferredContent = 6
    End Enum

    Friend Class ShareSourceFeatureItem

        Public Property DataType As ShareSourceFeatureItemType

        Public Property Text As String

        Public Property WebLink As Uri

        Public Property ApplicationLink As Uri

        Public Property Html As String

        Public Property Image As StorageFile

        Public Property StorageItems As IEnumerable(Of IStorageItem)

        Public Property DeferredDataFormatId As String

        Public Property GetDeferredDataAsyncFunc As Func(Of Task(Of Object))

        Private Sub New(ByVal dataType As ShareSourceFeatureItemType)
            DataType = dataType
        End Sub

        Friend Shared Function FromText(ByVal text As String) As ShareSourceFeatureItem
            Return New ShareSourceFeatureItem(ShareSourceFeatureItemType.Text) With {.Text = text}
        End Function

        Friend Shared Function FromWebLink(ByVal webLink As Uri) As ShareSourceFeatureItem
            Return New ShareSourceFeatureItem(ShareSourceFeatureItemType.WebLink) With {.WebLink = webLink}
        End Function

        Friend Shared Function FromApplicationLink(ByVal applicationLink As Uri) As ShareSourceFeatureItem
            Return New ShareSourceFeatureItem(ShareSourceFeatureItemType.ApplicationLink) With {.ApplicationLink = applicationLink}
        End Function

        Friend Shared Function FromHtml(ByVal html As String) As ShareSourceFeatureItem
            Return New ShareSourceFeatureItem(ShareSourceFeatureItemType.Html) With {.Html = html}
        End Function

        Friend Shared Function FromImage(ByVal image As StorageFile) As ShareSourceFeatureItem
            Return New ShareSourceFeatureItem(ShareSourceFeatureItemType.Image) With {.Image = image}
        End Function

        Friend Shared Function FromStorageItems(ByVal storageItems As IEnumerable(Of IStorageItem)) As ShareSourceFeatureItem
            Return New ShareSourceFeatureItem(ShareSourceFeatureItemType.StorageItems) With {.StorageItems = storageItems}
        End Function

        Friend Shared Function FromDeferredContent(ByVal deferredDataFormatId As String, ByVal getDeferredDataAsyncFunc As Func(Of Task(Of Object))) As ShareSourceFeatureItem
            Return New ShareSourceFeatureItem(ShareSourceFeatureItemType.DeferredContent) With {.DeferredDataFormatId = deferredDataFormatId, .GetDeferredDataAsyncFunc = getDeferredDataAsyncFunc}
        End Function
    End Class
End Namespace
