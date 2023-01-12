﻿using Cadmus.Refs.Bricks;

namespace Cadmus.Geo.Parts
{
    /// <summary>
    /// A toponym with an optional assertion.
    /// </summary>
    /// <seealso cref="IHasAssertion" />
    public class AssertedToponym : IHasAssertion
    {
        /// <summary>
        /// Gets or sets an optional tag. This can be used to distinguish different
        /// types of toponyms.
        /// </summary>
        public string? Tag { get; set; }

        /// <summary>
        /// Gets or sets an optional entity ID for this toponym.
        /// </summary>
        public string? Eid { get; set; }

        /// <summary>
        /// Gets or sets the toponym.
        /// </summary>
        public ProperName Name { get; set; }

        /// <summary>
        /// Gets or sets the optional assertion.
        /// </summary>
        public Assertion? Assertion { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssertedToponym"/> class.
        /// </summary>
        public AssertedToponym()
        {
            Name = new ProperName();
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{(Eid != null? "#" + Eid : "")} {Name}" +
                (Assertion != null ? "*" : "");
        }
    }
}
