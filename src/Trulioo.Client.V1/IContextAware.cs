namespace Trulioo.Client.V1
{
    public interface IContextAware
    {
        /// <summary>
        /// Gets the <see cref="Context"/> instance for this <see cref="ITruliooApiClient"/>.
        /// </summary>
        Context Context { get; }
    }
}
