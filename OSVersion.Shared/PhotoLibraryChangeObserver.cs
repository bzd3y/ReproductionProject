using BackgroundTasks;
using Photos;

namespace Sensus.iOS.Shared
{
	public class PhotoLibraryChangeObserver : PHPhotoLibraryChangeObserver
	{
		private PHFetchResult _imageFetchResult;

		public PhotoLibraryChangeObserver()
		{
			_imageFetchResult = PHAsset.FetchAssets(PHAssetMediaType.Image, new PHFetchOptions());
		}

		public override void PhotoLibraryDidChange(PHChange changeInstance)
		{
			PHFetchResultChangeDetails? imageDetails = changeInstance.GetFetchResultChangeDetails(_imageFetchResult);

			if (imageDetails?.InsertedObjects?.Length > 0)
			{
				_imageFetchResult = imageDetails.FetchResultAfterChanges;

				foreach (PHAsset image in imageDetails.InsertedObjects.OfType<PHAsset>())
				{
					PHImageRequestOptions options = new()
					{
						NetworkAccessAllowed = false,
						ResizeMode = PHImageRequestOptionsResizeMode.Exact,
						Version = PHImageRequestOptionsVersion.Original
					};

					if (OperatingSystem.IsIOSVersionAtLeast(13))
					{
						PHImageManager.DefaultManager.RequestImageDataAndOrientation(image, options, (d, t, o, i) =>
						{

						});

						BGTaskScheduler scheduler = BGTaskScheduler.Shared;
					}
					else
					{
						PHImageManager.DefaultManager.RequestImageData(image, options, (d, t, o, i) =>
						{

						});
					}
				}
			}
		}
	}
}
