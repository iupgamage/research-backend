// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Neo4JSample.Enums;
using Neo4JSample.Model;
using Neo4JSample.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neo4JSample.ConsoleApp.Services
{
    public interface IMovieDataService
    {

    }

    public class MovieDataService : IMovieDataService
    {

        public List<Trace> trace_data = new List<Trace>();
        Trace newTrace = new Trace();

        public List<Trace> Create(List<List<SpanDto>> traces)
        {
            foreach (var trace in traces)
            {
                newTrace = new Trace();
                var traceInfo = CreateRoot(trace);
                trace_data.Add(traceInfo);
            }
            var uniqueTraces = RemoveDuplicateTraces(trace_data);
            return uniqueTraces;
        }

        public Trace CreateRoot(List<SpanDto> trace)
        {
            var rootSpan = trace.Where(x => x.parentId == null).FirstOrDefault();
            var childrenOfRootSpan = trace.Where(x => x.parentId == rootSpan.id && x.kind == Kind.SERVER.ToString()).ToList();

            CreateInfo(rootSpan, null, childrenOfRootSpan, trace);

            return newTrace;
        }

        public void CreateInfo(SpanDto span, SpanDto parentSpan, List<SpanDto> childSpans, List<SpanDto> trace)
        {
            var serviceInfo = new ServiceInformation();
            var serviceInfo_ch = new ServiceInformation();

            var svc = Convert.ToInt32(Community.service);
            var clnt = Convert.ToInt32(Community.client);

            if (span != null)
            {
                var service = new Service
                {
                    Name = span.localEndpoint.ServiceName,
                    TraceId = "null",
                    EndPoint = "null",
                    Community = !string.IsNullOrEmpty(span.parentId) ? svc : clnt
                };
                serviceInfo.Service = service;

                var service_ch = new Service
                {
                    Name = span.localEndpoint.ServiceName,
                    TraceId = span.traceId,
                    EndPoint = span.Tags.httpPath,
                    Community = !string.IsNullOrEmpty(span.parentId) ? svc : clnt
                };
                serviceInfo_ch.Service = service_ch;
            }

            if (parentSpan != null)
            {
                var parentService = new Service
                {
                    Name = parentSpan.localEndpoint.ServiceName,
                    TraceId = "null",
                    EndPoint = "null",
                    Community = !string.IsNullOrEmpty(parentSpan.parentId) ? svc : clnt
                };
                serviceInfo.FromServices.Add(parentService);

                var parentService_ch = new Service
                {
                    Name = parentSpan.localEndpoint.ServiceName,
                    TraceId = parentSpan.traceId,
                    EndPoint = parentSpan.Tags.httpPath,
                    Community = !string.IsNullOrEmpty(parentSpan.parentId) ? svc : clnt
                };
                serviceInfo_ch.FromServices.Add(parentService_ch);
            }

            if (childSpans != null && childSpans.Count() > 0)
            {
                var childServices = childSpans.Select(x => new Service
                {
                    Name = x.localEndpoint.ServiceName,
                    TraceId = "null",
                    EndPoint = "null",
                    Community = svc
                }).ToList();
                serviceInfo.ToServices = childServices;

                var childServices_ch = childSpans.Select(x => new Service
                {
                    Name = x.localEndpoint.ServiceName,
                    TraceId = x.traceId,
                    EndPoint = x.Tags.httpPath,
                    Community = svc
                }).ToList();
                serviceInfo_ch.ToServices = childServices_ch;
            }

            newTrace.serviceinformation.Add(serviceInfo);
            newTrace.serviceinformation.Add(serviceInfo_ch);

            foreach (var childSpan in childSpans)
            {
                var parentSpan2= trace.Where(x => x.id == childSpan.parentId && x.kind == Kind.SERVER.ToString()).FirstOrDefault();
                var childSpans2= trace.Where(x => x.parentId == childSpan.id && x.kind == Kind.SERVER.ToString()).ToList();

                CreateInfo(childSpan, parentSpan2, childSpans2, trace);
            }
        }

        public List<Trace> RemoveDuplicateTraces(List<Trace> traces) 
        {
            var uniqueTraces = traces.GroupBy(x => x.EndpointsAsString).Select(x => x.First()).ToList();
            return uniqueTraces;
        }
             
    }
}
