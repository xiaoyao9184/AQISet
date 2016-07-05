FORMAT: 1A
HOST: http://earth.nullschool.net




# nullschool全球风发布系统

文档日期 2016-07-05
系统地址 http://earth.nullschool.net。




# oscar [GET /data/oscar/oscar-catalog.json]
oscar

+ Response 200 (application/json)

    + Body

            [
              "20111206-surface-currents-oscar-0.33.epak",
              "20111211-surface-currents-oscar-0.33.epak"
            ]




# topo [GET /data/earth-topo.json{?v}]
topo

+ Parameters

    + v: v3 (string, required) - ??

+ Response 200 (application/json)

    + Body

            {
              "type":"Topology",
              "transform":
              {
                "scale":
                [
                  0.036003600360036005,
                  0.016927109488408615
                ],
                "translate":
                [
                  -180,
                  -85.60903777459774
                ]
              },
              "objects":
              {
                "coastline_50m":
                {
                  "type": "GeometryCollection",
                  "geometries":
                  [
                    {
                      "type": "LineString",
                      "arcs":
                      [
                        3164,
                        3414
                      ]
                    }
                  ]
                },
                "coastline_110m":
                {
                  "type": "GeometryCollection",
                  "geometries":
                  [
                    {
                      "type": "LineString",
                      "arcs":
                      [
                        3164,
                        3414
                      ]
                    }
                  ]
                },
                "lakes_50m":
                {
                  "type": "GeometryCollection",
                  "geometries":
                  [
                    {
                      "type": "LineString",
                      "arcs":
                      [
                        3164,
                        3414
                      ]
                    }
                  ]
                },
                "lakes_110m":
                {
                  "type": "GeometryCollection",
                  "geometries":
                  [
                    {
                      "type": "LineString",
                      "arcs":
                      [
                        3164,
                        3414
                      ]
                    }
                  ]
                },
                "rivers_50m":
                {
                  "type": "GeometryCollection",
                  "geometries":
                  [
                    {
                      "type": "LineString",
                      "arcs":
                      [
                        3164,
                        3414
                      ]
                    }
                  ]
                },
                "rivers_110m":
                {
                  "type": "GeometryCollection",
                  "geometries":
                  [
                    {
                      "type": "LineString",
                      "arcs":
                        [
                          3164,
                          3414
                        ]
                    }
                  ]
                }
              },
              "arcs":
              [
                [
                  9999,
                  4103
                ],
                [
                  -4,
                  -3
                ]
              ]
            }



# weather [GET /data/weather/current/current-wind-surface-level-gfs-0.5.epak]
??，还存在一个非本域名的接口
https://gaia.nullschool.net/data/gfs/current/current-wind-surface-level-gfs-0.5.epak

+ Response 200 (text/plain)
