namespace System.Text
{
    /// <summary>
    /// Random Name Generator interface
    /// </summary>
    public interface INamesGenerator
    {
        /// <summary>
        /// Generate random names
        /// </summary>
        /// <returns>Random name string</returns>
        string GetRandomName();
    }
}
