//***********************************************************************
// Assembly         : Orbita.Framework
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Globalization;
using System.Collections;
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Keeps logging configuration and provides simple API
    /// to modify it.
    /// </summary>
    public class TargetConfiguration
    {
        internal TargetDictionary _targets = new TargetDictionary();
        internal TargetCollection _aliveTargets = new TargetCollection();

        /// <summary>
        /// Creates new instance of LoggingConfiguration object.
        /// </summary>
        public TargetConfiguration() { }

        /// <summary>
        /// Registers the specified target object under a given name.
        /// </summary>
        /// <param name="name">Name of the target.</param>
        /// <param name="target">The target object.</param>
        public void AddTarget(string name, Target target)
        {
            if (name == null)
                throw new ArgumentException("name", "Target name cannot be null");
            _targets[name.ToLower(CultureInfo.InvariantCulture)] = target;
        }

        /// <summary>
        /// Removes the specified named target.
        /// </summary>
        /// <param name="name">Name of the target.</param>
        public void RemoveTarget(string name)
        {
            _targets.Remove(name.ToLower(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Finds the target with the specified name.
        /// </summary>
        /// <param name="name">The name of the target to be found.</param>
        /// <returns>Found target or <see langword="null" /> when the target is not found.</returns>
        public Target FindTargetByName(string name)
        {
            return _targets[name.ToLower(CultureInfo.InvariantCulture)];
        }


        /// <summary>
        /// A collection of file names which should be watched for changes by NLog.
        /// </summary>
        public virtual ICollection FileNamesToWatch
        {
            get { return null; }
        }

        /// <summary>
        /// Called by LogManager when one of the log configuration files changes.
        /// </summary>
        /// <returns>A new instance of <see cref="LoggingConfiguration" /> that represents the updated configuration.</returns>
        public virtual TargetConfiguration Reload()
        {
            return this;
        }


        /// <summary>
        /// Flushes any pending log messages on all appenders.
        /// </summary>
        internal void FlushAllTargets(TimeSpan timeout)
        {
            foreach (Target target in _targets.Values)
            {
                try
                {
                    target.Flush(timeout);
                }
                catch (Exception ex)
                {
                }
            }
        }

        internal void InitializeAll()
        {
            foreach (Target target in _aliveTargets)
            {
                try
                {
                    target.Initialize();

                }
                catch (Exception ex)
                {
                }
            }
        }

        /// <summary>
        /// Returns a collection of named targets specified in the configuration.
        /// </summary>
        /// <returns>A <see cref="TargetCollection"/> object that contains a list of named targets.</returns>
        /// <remarks>
        /// Unnamed targets (such as those wrapped by other targets) are not returned.
        /// </remarks>
        public TargetCollection GetConfiguredNamedTargets()
        {
            TargetCollection tc = new TargetCollection();
            foreach (Target t in _targets.Values)
            {
                tc.Add(t);
            }
            return tc;
        }


        /// <summary>
        /// Closes all targets and releases any unmanaged resources.
        /// </summary>
        public void Close()
        {
            foreach (Target target in _aliveTargets)
            {
                try
                {
                    target.Close();
                }
                catch
                {
                }
            }
        }
    }
}