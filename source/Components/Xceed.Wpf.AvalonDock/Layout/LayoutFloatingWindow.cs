﻿/*************************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace Xceed.Wpf.AvalonDock.Layout
{
  [Serializable]
  public abstract class LayoutFloatingWindow : LayoutElement, ILayoutContainer, IXmlSerializable
  {
    /// <summary>
    /// Log4net logger facility for this class.
    /// </summary>
    protected new static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    #region Constructors

    public LayoutFloatingWindow()
    {
    }

    #endregion

    #region Properties

    #region Children

    public abstract IEnumerable<ILayoutElement> Children
    {
      get;
    }

    #endregion

    #region ChildrenCount

    public abstract int ChildrenCount
    {
      get;
    }

    #endregion

    #region IsValid

    public abstract bool IsValid
    {
      get;
    }

    #endregion

    #endregion

    #region Public Methods

    public abstract void RemoveChild( ILayoutElement element );

    public abstract void ReplaceChild( ILayoutElement oldElement, ILayoutElement newElement );

    public XmlSchema GetSchema()
    {
      return null;
    }

    public abstract void ReadXml( XmlReader reader );

    public virtual void WriteXml( XmlWriter writer )
    {
      Logger.InfoFormat("_");

      foreach( var child in Children )
      {
        var type = child.GetType();
        var serializer = new XmlSerializer( type );
        serializer.Serialize( writer, child );
      }
    }

    #endregion
  }
}
