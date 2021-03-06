﻿// ***********************************************************************
// Assembly         : Wulka.SessionProxy.Contract.Test
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-04-2013
// ***********************************************************************
// <copyright file="SessionProxyTest.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Broobu.SessionProxy.Contract.Agent;
using Broobu.SessionProxy.Contract.Interfaces;
using Wulka.Agent;
using Wulka.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wulka.Domain.Authentication;
using Wulka.Test;

namespace Broobu.SessionProxy.Contract.Test
{
    /// <summary>
    /// Class SessionProxyTest.
    /// </summary>
    [TestClass]
    public class SessionProxyTest : ServiceTestFixtureBase, ISessionProxy, IQuerySession
    {


        [TestMethod]
        public override void Try_GetServiceEndpoints()
        {
            base.Try_GetServiceEndpoints();
        }







        /// <summary>
        /// Try_s the get sessions.
        /// </summary>
        [TestMethod]
        public void Try_GetSessions()
        {
            var res = GetSessions();
            foreach (var WulkaSession in res)
            {
                Console.WriteLine(String.Format("Name : {0}", WulkaSession.Username));
            }
        }


        [TestMethod]
        public void Try_StartSession()
        {
            var inp = SessionFactory.CreateDefaultWulkaSession();
            StartSession(inp);
        }


        /// <summary>
        /// Starts the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>WulkaSession.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public WulkaSession StartSession(WulkaSession session)
        {
            return SessionProxyPortal
                .SessionProxy
                .StartSession(session);
        }

        /// <summary>
        /// Gets the sessions.
        /// </summary>
        /// <returns>WulkaSession[][].</returns>
        public WulkaSession[] GetSessions()
        {
            return SessionProxyPortal
                .QuerySession
                .GetSessions();
        }

        /// <summary>
        /// Ends the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>WulkaSession.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public WulkaSession EndSession(WulkaSession session)
        {
            return SessionProxyPortal
                .SessionProxy
                .EndSession(session);
        }

        protected override string GetContractType()
        {
            return String.Format("{0}:IQuerySession", SessionServiceConst.Namespace);
        }
    }
}
