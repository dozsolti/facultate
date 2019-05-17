import { Injectable } from '@angular/core';
import { Httpro } from './httpro/httpro.service';

@Injectable({
    providedIn: 'root'
})
export class BookService {

    constructor(private httpro: Httpro) { }

    getBooksForHomePage() {
        return [
            {
                "volumeInfo": {
                    "title": "Mom-Bre",
                    "authors": [
                        "James H. Wilkinson"
                    ],
                    "publisher": "AuthorHouse",
                    "publishedDate": "2007-06-15",
                    "description": "Terri Linville thought she was going to the Amazon to work on her Thesis. Instead she finds herself in the middle of a terrorists plot.She getshelp from her father, Sam Linville, head of the NSA, and other charactors whose experiences tend to overlap around a web of intrigue with potentially wide reaching implications. After a grisley find she learns of a mystical creature called MOM-BRE. A creature that eats the muscles of a body and leaves the skin and bones. With time running out Terri, Dr. James Newhouse, and the rest of the team, set off to find Dr. Keller and the team abducted by the terrorists. Taking into account an understanding of certain contemporary political and cultural conditions, with elements of suspense and emotion,you will explore the relative complexities of human nature and interaction as well as capturing theimaginationand to provoke thought.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_10",
                            "identifier": "1467088390"
                        },
                        {
                            "type": "ISBN_13",
                            "identifier": "9781467088398"
                        }
                    ],
                    "pageCount": 180,
                    "categories": [
                        "Fiction"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=Niwuc1LblAsC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=Niwuc1LblAsC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "BRE-X: DEAD MAN’S STORY?",
                    "authors": [
                        "Alfred Lenarciak"
                    ],
                    "publisher": "AuthorHouse",
                    "publishedDate": "2014-01-17",
                    "description": "Between 1994 and 1997, Canadian-based Bre-X Minerals sponsored and enthusiastically promoted listings on the TSX and NASDAQ by JPMorgan, Lehman, BMO, Scotia as well as others, who were exploring for gold on the Busang property on the Indonesian island of Borneo. Their efforts bore the discovery of a lifetime: a mammoth deposit speculated to contain over 200 million ounces of easily extractable gold. The company’s stock exploded from 25 cents to $270, giving them a valuation of over $6 billion. Major mining companies like Barrick, Placer Dome and Freeport McMoran started competing to develop the largest gold deposit ever discovered. In early 1997, Suharto and his Indonesian government took control of the deposit, by force, and commissioned Freeport to build a mega mine. In the ensuing months, due diligence revealed that the deposit was a gigantic hoax! There was no gold in Busang. The principals of Bre-X were accused (but never convicted) of salting (adding gold) the samples before sending them to the labs. Michael de Guzman, a Filipino geologist who served as the project manager, infamously jumped from a helicopter into the abyss of Borneo’s jungle. Minorca Resources of Toronto were the financial partners of the Haji Saykerani group of companies who owned Busang. Alfred Lenarciak was the chairman of Minorca at the time. In a strange twist of fate, in February of 2012, Alfred had a chance encounter in Rome, Italy with a man named Akiro Guzzo, who shared with him an amazing story on the life and death of Michael de Guzman: is this really a dead man’s story?",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9781491847862"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "1491847867"
                        }
                    ],
                    "pageCount": 258,
                    "categories": [
                        "Business & Economics"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=STakAgAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=STakAgAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Gold of Bre-X",
                    "authors": [
                        "Alfred Lenarciak"
                    ],
                    "publisher": "BookVenture Publishing LLC",
                    "publishedDate": "2017-01-19",
                    "description": "Between 1994 and 1997, Canadian company Bre-X Minerals, sponsored and promoted to listings on the TSX and NASDAQ by JPMorgan, Lehman, BMO, and others, was exploring for gold on the Busang property on the Indonesian island of Borneo. Bre-X's efforts bore the discovery of a lifetime: a mammoth deposit estimated to contain over 200 million ounces of easily extractable gold. The company's stock exploded from 25 cents to over $270, effectively valuing Bre-X at over $6 billion and attracting the interest of major mining companies. Barrick, Placer Dome, and Freeport McMorran, all the major players at the time, started competing to develop the largest gold deposit ever discovered. In early 1997, Indonesian President Suharto and his government took control of the deposit by force and commissioned Freeport to build a mega mine. In the ensuing months, due diligence revealed that the deposit was a gigantic hoax! There was no gold in Busang. The principals of Bre-X were accused, but never convicted, of salting samples before sending them to labs. Michael de Guzman, a Filipino geologist who served as the project manager, allegedly committed suicide by jumping from a helicopter into the abyss of Borneo's jungle. Minorca Resources of Toronto were the financial partners of the Haji Sayakarani group of companies that owned Busang; Alfred Lenarciak was the chairman of Minorca at the time. In a strange twist of fate, in February 2012, Alfred had a chance encounter in Rome with a man by the name of Akiro Guzzo, who shared with him an amazing story about the life and death of Michael de Guzman, the creator of a fake gold mega deposit. Is this really a dead man's story?",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9781946250469"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "1946250465"
                        }
                    ],
                    "pageCount": 152,
                    "categories": [
                        "Fiction"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=lBrxDQAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=lBrxDQAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Multicultural Fables and Fairy Tales",
                    "authors": [
                        "Tara McCarthy"
                    ],
                    "publisher": "Scholastic Inc.",
                    "publishedDate": "1993",
                    "description": "Recounts 24 fairy tales with accompanying teaching suggestions and activity sheets.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_10",
                            "identifier": "0590492314"
                        },
                        {
                            "type": "ISBN_13",
                            "identifier": "9780590492317"
                        }
                    ],
                    "pageCount": 112,
                    "categories": [
                        "Social Science"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=A7ZqxZYeAC0C&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=A7ZqxZYeAC0C&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Bre Bre and Bj Written and Illustrated by Bryan Kilgore",
                    "authors": [
                        "Kilgore Studios 75 Cornbread Comics",
                        "Bryan Kilgore, Sr."
                    ],
                    "publishedDate": "2010-03-26",
                    "description": "This sister and brother combo meal needs no introduction. You can just open the book and find out what they are doing next. They are always on an adventure filled with fun and excitement. If you like candy, then you will enjoy the flavor of \"bre bre & bj!\"",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_10",
                            "identifier": "0615363377"
                        },
                        {
                            "type": "ISBN_13",
                            "identifier": "9780615363370"
                        }
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=9S91RQAACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=9S91RQAACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Routledge German Dictionary of Information Technology",
                    "authors": [
                        "Routledge (Firm)"
                    ],
                    "publisher": "Psychology Press",
                    "publishedDate": "1996",
                    "description": "Beginning with an introduction that examines the portrayal of the characters of Lancelot and Guinevere from their origins to the present day, this collection of 16 essays-five of which appear here for the first time-puts particular emphasis on the appearance of the two characters in medieval and modern literature. Besides several studies exploring feminist concerns, the volume features articles on the representation of the lovers in medieval manuscript illuminations (18 plates focus on scenes of their first kiss and the consummation of the adultery), in film, and in other visual arts. A 200-item bibliography completes the volume.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_10",
                            "identifier": "0415086469"
                        },
                        {
                            "type": "ISBN_13",
                            "identifier": "9780415086462"
                        }
                    ],
                    "pageCount": 436,
                    "categories": [
                        "Business & Economics"
                    ],
                    "averageRating": 4,
                    "ratingsCount": 1,
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=oTtRZzSX3ggC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=oTtRZzSX3ggC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "The Western Monthly Magazine",
                    "authors": [
                        "James Hall",
                        "Joseph Reese Fry"
                    ],
                    "publishedDate": "1835",
                    "industryIdentifiers": [
                        {
                            "type": "OTHER",
                            "identifier": "OSU:32435074054917"
                        }
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=Rc9CAQAAMAAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=Rc9CAQAAMAAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Routledge French Technical Dictionary Dictionnaire technique anglais",
                    "authors": [
                        "Yves Arden"
                    ],
                    "publisher": "Routledge",
                    "publishedDate": "2006-03-21",
                    "description": "The French-English volume of this highly acclaimed set consists of some 100,000 keywords in both French and English, drawn from the whole range of modern applied science and technical terminology. Covers over 70 subject areas, from engineering and chemistry to packaging, transportation, data processing and much more.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9781134831715"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "1134831714"
                        }
                    ],
                    "pageCount": 816,
                    "categories": [
                        "Reference"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=_9oqBgAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=_9oqBgAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "MU/13A-English Spelling for EFL Students",
                    "authors": [
                        "Paula López Rua"
                    ],
                    "publisher": "Univ Santiago de Compostela",
                    "publishedDate": "2013-06-18",
                    "description": "This manual provides both intermediate and advanced level students of English as a Foreign Language with further knowledge and practice so as to make them improve their spelling skills. The book is divided into six chapters, and its contents are based on the analysis of a corpus of spelling errors spotted in exams, essays and exercises done by Spanish university students. The manual can be used for self-study, since it also includes an answer key at the back, where students can check the correct or suggested answers to all the exercises.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9788498878103"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "8498878101"
                        }
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=4hl1daXN5VMC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=4hl1daXN5VMC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "WAZZUP? Dicţionar de argou şi engleză colocvială",
                    "authors": [
                        "Linghea S.R.L."
                    ],
                    "publisher": "Linghea S.R.L.",
                    "publishedDate": "2014-06-24",
                    "description": "Vă prezentăm cel mai nou şi mai fidel dicţionar de argou englez–român. Acesta cuprinde şi liste cu explicaţii utile ale abrevierilor folosite pe Internet şi lista de rime Cockney. Wazzup? Traducem strada, filmele şi Internetul.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9786068491370"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "6068491374"
                        }
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=p6GWBAAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=p6GWBAAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "ro"
                }
            },
            {
                "volumeInfo": {
                    "title": "Br'er Rabbit's Laffin' Place",
                    "publisher": "EDCON Publishing Group",
                    "publishedDate": "2011-08",
                    "description": "Enjoy a delightful excursion into the wonderful world of make-believe, where fairy-tales and old favorite stories come vividly to life. Narration by expert storytellers, music, exciting sound effects, and dramatic dialogue will inspire. This classic tale is sure to become a favorite pass-time, treating children to a magical fantasy of entertaining enjoyment along with life lessons to which they can relate.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9780848108571"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "0848108574"
                        }
                    ],
                    "pageCount": 12,
                    "categories": [
                        "African Americans"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=CPM6NAa8b8QC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=CPM6NAa8b8QC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Routledge Dictionnaire Technique Anglais",
                    "authors": [
                        "Yves Arden"
                    ],
                    "publisher": "Psychology Press",
                    "publishedDate": "1994",
                    "description": "The French-English volume of this highly acclaimed set consists of some 100,000 keywords in both French and English, drawn from the whole range of modern applied science and technical terminology. Covers over 70 subject areas, from engineering and chemistry to packaging, transportation, data processing and much more.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9780415112246"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "0415112249"
                        }
                    ],
                    "pageCount": 1618,
                    "categories": [
                        "Reference"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=6l8hIXy_A5cC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=6l8hIXy_A5cC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "A New French and English Pronouncing Dictionary on the Basis of Nugent's, with Many New Words in General Use",
                    "authors": [
                        "F. C. Meadows"
                    ],
                    "publishedDate": "1835",
                    "industryIdentifiers": [
                        {
                            "type": "OTHER",
                            "identifier": "HARVARD:HNJYMP"
                        }
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=040NAAAAYAAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=040NAAAAYAAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "The Green Guide to Specification",
                    "authors": [
                        "Jane Anderson",
                        "David Shiers",
                        "Mike Sinclair"
                    ],
                    "publisher": "John Wiley & Sons",
                    "publishedDate": "2008-04-15",
                    "description": "How can you tell if the materials and components you are specifying have a low environmental impact? A full life-cycle assessment is a complex, time-consuming and expensive process; the environmental ratings summarised in this Guide provide a quick and easy way for designers and specifiers to assess their options. The relative environmental performance of over 250 materials and components have been assessed in this guide, using carefully researched, quantitative data derived from the BRE Environmental Database. A wide range of alternative specifications are provided for: · walls · floor systems · floor finishes · roofs · windows · doors · ceilings · paints · insulation · landscaping. The performance of each specification is measured against a range of environmental impacts including: · climate change · toxicity · fossil fuel and ozone depletion · levels of emissions and pollutants · mineral and water extraction. Environmental performance is indicated by a simple to use A-B-C rating system. To further aid specifiers, guidance on capital coasts, typical replacement intervals and information on recycling is also provided for each material and component. An important part of BREEAM, the BRE's widely accepted scheme to improve the environmental performance of buildings, The Green Guide to Specification is an essential tool for architects, surveyors, building managers and property owners seeking to reduce the environmental impacts of building materials through informed choice.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9780470680391"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "0470680393"
                        }
                    ],
                    "pageCount": 112,
                    "categories": [
                        "Architecture"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=2I9MW3rlK9sC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=2I9MW3rlK9sC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Focus BrE 5 Students' Book and PTE-G Level 4 (C1) Pack",
                    "authors": [
                        "Vaughan Jones",
                        "Sue Kay",
                        "Monica Berlis",
                        "Heather Jones"
                    ],
                    "publishedDate": "2017-02-15",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_10",
                            "identifier": "1292169532"
                        },
                        {
                            "type": "ISBN_13",
                            "identifier": "9781292169538"
                        }
                    ],
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Waterbirds Around the World",
                    "authors": [
                        "G. C. Boere",
                        "Colin A. Galbraith",
                        "David A. Stroud"
                    ],
                    "publisher": "The Stationery Office",
                    "publishedDate": "2006",
                    "description": "This book is the outcome of a major international conference on waterbirds held in Edinburgh in April 2004.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9780114973339"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "0114973334"
                        }
                    ],
                    "pageCount": 940,
                    "categories": [
                        "Flyways"
                    ],
                    "averageRating": 1,
                    "ratingsCount": 1,
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=4htx09cb-6gC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=4htx09cb-6gC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Hepatocellular Carcinoma: New Insights for the Healthcare Professional: 2011 Edition",
                    "publisher": "ScholarlyEditions",
                    "publishedDate": "2012-01-09",
                    "description": "Hepatocellular Carcinoma: New Insights for the Healthcare Professional: 2011 Edition is a ScholarlyEditions™ eBook that delivers timely, authoritative, and comprehensive information about Hepatocellular Carcinoma. The editors have built Hepatocellular Carcinoma: New Insights for the Healthcare Professional: 2011 Edition on the vast information databases of ScholarlyNews.™ You can expect the information about Hepatocellular Carcinoma in this eBook to be deeper than what you can access anywhere else, as well as consistently reliable, authoritative, informed, and relevant. The content of Hepatocellular Carcinoma: New Insights for the Healthcare Professional: 2011 Edition has been produced by the world’s leading scientists, engineers, analysts, research institutions, and companies. All of the content is from peer-reviewed sources, and all of it is written, assembled, and edited by the editors at ScholarlyEditions™ and available exclusively from us. You now have a source you can cite with authority, confidence, and credibility. More information is available at http://www.ScholarlyEditions.com/.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9781464900525"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "1464900523"
                        }
                    ],
                    "pageCount": 310,
                    "categories": [
                        "Medical"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=KpjzAeb67ocC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=KpjzAeb67ocC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "IELTS Express",
                    "authors": [
                        "Richard Hallows",
                        "Martin Lisboa",
                        "Richard Howells",
                        "Mark Unwin"
                    ],
                    "publisher": "Heinle & Heinle Pub",
                    "publishedDate": "2012",
                    "description": "A preparation course for candidates studying for the International English Language Testing System examination (IELTS)",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_10",
                            "identifier": "113331306X"
                        },
                        {
                            "type": "ISBN_13",
                            "identifier": "9781133313069"
                        }
                    ],
                    "pageCount": 144,
                    "categories": [
                        "Education"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=p_9PtgEACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=p_9PtgEACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "The Western Monthly Magazine, and Literary Journal",
                    "publishedDate": "1834",
                    "industryIdentifiers": [
                        {
                            "type": "OTHER",
                            "identifier": "CHI:74711872"
                        }
                    ],
                    "categories": [
                        "Cincinnati (Ohio)"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=_y84AQAAMAAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=_y84AQAAMAAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "An Insider's Guide to the Mining Sector",
                    "authors": [
                        "Michael Coulson"
                    ],
                    "publisher": "Harriman House Limited",
                    "publishedDate": "2008",
                    "description": "- In 2003, four mining shares rose over four times in price, with one gaining ten times.- In just the first two months of 2004, 26 mining shares increased more than 20%, with five shares doubling.- Merrill Lynch's World Mining Trust is the UK's best performing fund over the past three years, having risen by over 200 per cent.But is the mining boom about to end?Not according to this book, by Michael Coulson, Chairman of the Association of Mining Analysts. Coulson argues that, if anything, we are still in the early stages of prolonged strength in mining stocks and despite what some commentators are saying, the boom is far from over.FROM THE BACK COVERThe prospect of instant riches gives the mining sector an obvious glamour. And when the mining sector begins to run it can be an awesome sight and the excitement generated can be every bit as seductive and heady as that which enveloped markets during the internet boom. But due to the counter-cyclical nature of many mining stocks, they can also offer a valuable refuge when stock markets turn down. In this book, Michael Coulson gives a masterly overview of the sector, explains both the rewards and the pitfalls of investing in mining shares and argues convincingly that mining should once again form a core sector for all investors. The book is for anyone interested in mining, and particularly mining as an investment. Whilst it contains material which will be useful to even experienced followers of the sector, its main target is those who are interested in mining but perhaps not particularly familiar with the sector, and would like to know more. All the subjects are covered that are fundamental to acquiring sufficient knowledge about the miningsector to invest in it with confidence.While the mining s",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9781905641550"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "1905641559"
                        }
                    ],
                    "pageCount": 360,
                    "categories": [
                        "Business & Economics"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=jyraAgAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=jyraAgAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Building Research Establishment Information Paper",
                    "publishedDate": "1979",
                    "industryIdentifiers": [
                        {
                            "type": "OTHER",
                            "identifier": "MINN:31951D01097615T"
                        }
                    ],
                    "categories": [
                        "Building"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=CEYnuQEACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=CEYnuQEACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Focus BrE 2 Teacher's Book for Pack",
                    "authors": [
                        "Patricia Reilly",
                        "Anna Grodzicka"
                    ],
                    "publishedDate": "2016-04-11",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_10",
                            "identifier": "1447997948"
                        },
                        {
                            "type": "ISBN_13",
                            "identifier": "9781447997948"
                        }
                    ],
                    "pageCount": 240,
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=48NwjgEACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=48NwjgEACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Green Building Certification Systems",
                    "authors": [
                        "Thilo Ebert",
                        "Natalie Eßig",
                        "Gerd Hauser"
                    ],
                    "publisher": "Walter de Gruyter",
                    "publishedDate": "2011-01-01",
                    "description": "Certification systems for buildings aim to make sustainability transparent for the general public and economically feasible for investors. Several hundred systems have been developed since around 1990.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9783955531683"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "3955531686"
                        }
                    ],
                    "pageCount": 144,
                    "categories": [
                        "Art"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=pYzTAAAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=pYzTAAAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "2029",
                    "authors": [
                        "Tim Wuebker"
                    ],
                    "publisher": "First Edition Design Pub.",
                    "publishedDate": "2012-08-12",
                    "description": "Welcome to America in 2029 ... A depression economy. A delayed presidential election. A series of terrorist attacks. And a president who will do anything to win. Gripping and provocative, 2029 is more than an action-packed thrill ride. It is an eerily prophetic novel that will stay with you long after the final moment of suspense.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9781622870585"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "1622870581"
                        }
                    ],
                    "pageCount": 178,
                    "categories": [
                        "Fiction"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=Nc5Pbx-EZogC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=Nc5Pbx-EZogC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Bre Housing Design Handbook",
                    "authors": [
                        "Building Research Establishment"
                    ],
                    "publisher": "Bre Press",
                    "publishedDate": "2010-11",
                    "description": "This handbook encapsulates much of BRE's expertise relating to the design of housing, and is addressed to all owners, designers and maintainers of housing stock. It provides a reference manual of basic information on housing, whether new or refurbished. It is intended to help clients, contractors, developers and all involved in housebuilding, in both the private and public sectors, to appreciate the wide range of user requirements that must be addressed in the design of housing. As a reference book it provides a means of checking that housing design criteria have been met adequately. It also suggests how to achieve customer satisfaction by meeting their most important needs.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_10",
                            "identifier": "1860811639"
                        },
                        {
                            "type": "ISBN_13",
                            "identifier": "9781860811630"
                        }
                    ],
                    "pageCount": 299,
                    "categories": [
                        "Architecture"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=f0etAAAACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=f0etAAAACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Kowalchyk and Lancaster's Favorite Solos, Book 2",
                    "authors": [
                        "Gayle Kowalchyk",
                        "E. L. Lancaster"
                    ],
                    "publisher": "Alfred Music",
                    "publishedDate": "2012-03-22",
                    "description": "The contents of this book represent Gayle Kowalchyk and E. L. Lancaster’s favorite sheet music solos. Many of the solos are among the most requested by piano teachers and students alike. Several of the pieces are based on patterns for easy learning. This book contains 12 late elementary to early intermediate pieces. Titles: *Caribbean Holiday *The Chase *Dream Echoes *Drifting Flight *Master Mind *Midnight Dance *Paw Prints at My Door *Sombrero Sam *Toccatina *Toccatina Twister *Topsy-Turvy *Valentine Masquerade",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9781470624880"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "1470624885"
                        }
                    ],
                    "pageCount": 32,
                    "categories": [
                        "Music"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=YiWQBQAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=YiWQBQAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Focus BrE 4 Student's Book for MyEnglishLab Pack",
                    "authors": [
                        "Vaughan Jones",
                        "Sue Kay",
                        "Daniel Brayshaw"
                    ],
                    "publishedDate": "2016-05-09",
                    "description": "Focus is a rich, varied, carefully levelled course for upper secondary students. Specially designed to motivate older teens, it helps them to track their level and achieve the exam results they need. With its unique blended learning package, Focus is the flexible course that gets results.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_10",
                            "identifier": "1447998308"
                        },
                        {
                            "type": "ISBN_13",
                            "identifier": "9781447998303"
                        }
                    ],
                    "pageCount": 144,
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=NyUAjwEACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=NyUAjwEACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api"
                    },
                    "language": "en"
                }
            },
            {
                "volumeInfo": {
                    "title": "Focus BrE 3 Workbook",
                    "authors": [
                        "Daniel Brayshaw",
                        "Bartosz Michalowski"
                    ],
                    "publishedDate": "2016-01-22",
                    "description": "Focus is a rich, varied, carefully levelled course for upper secondary students. Specially designed to motivate older teens, it helps them to track their level and achieve the exam results they need. With its unique blended learning package, Focus is the flexible course that gets results.",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_10",
                            "identifier": "1447998170"
                        },
                        {
                            "type": "ISBN_13",
                            "identifier": "9781447998174"
                        }
                    ],
                    "pageCount": 136,
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=wnEgjgEACAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=wnEgjgEACAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api"
                    },
                    "language": "en"
                }
            },

            {
                "volumeInfo": {
                    "title": "An Introduction to Forensic Geoscience",
                    "authors": [
                        "Elisa Bergslien"
                    ],
                    "publisher": "John Wiley & Sons",
                    "publishedDate": "2012-04-30",
                    "description": "\"Introduces geological fundamentals through medium of forensic science\"--",
                    "industryIdentifiers": [
                        {
                            "type": "ISBN_13",
                            "identifier": "9781405160544"
                        },
                        {
                            "type": "ISBN_10",
                            "identifier": "1405160543"
                        }
                    ],
                    "pageCount": 482,
                    "categories": [
                        "Law"
                    ],
                    "imageLinks": {
                        "smallThumbnail": "http://books.google.com/books/content?id=DuOHHh-eIFcC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=DuOHHh-eIFcC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                    },
                    "language": "en"
                }
            }
        ]
            .map(this.PipeSmallBook);
    }

    getBookByISBN(model, isbn) {
        return this.httpro
            .get(`https://www.googleapis.com/books/v1/volumes?prettyPrint=false&orderBy=newest&q=isbn:${isbn}`)
            .to(model)
            .exec();
        /* return this.PipeFullBook({
            "volumeInfo": {
                "title": "Mom-Bre",
                "authors": [
                    "James H. Wilkinson"
                ],
                "publisher": "AuthorHouse",
                "publishedDate": "2007-06-15",
                "description": "Terri Linville thought she was going to the Amazon to work on her Thesis. Instead she finds herself in the middle of a terrorists plot.She getshelp from her father, Sam Linville, head of the NSA, and other charactors whose experiences tend to overlap around a web of intrigue with potentially wide reaching implications. After a grisley find she learns of a mystical creature called MOM-BRE. A creature that eats the muscles of a body and leaves the skin and bones. With time running out Terri, Dr. James Newhouse, and the rest of the team, set off to find Dr. Keller and the team abducted by the terrorists. Taking into account an understanding of certain contemporary political and cultural conditions, with elements of suspense and emotion,you will explore the relative complexities of human nature and interaction as well as capturing theimaginationand to provoke thought.",
                "industryIdentifiers": [
                    {
                        "type": "ISBN_10",
                        "identifier": "1467088390"
                    },
                    {
                        "type": "ISBN_13",
                        "identifier": "9781467088398"
                    }
                ],
                "pageCount": 180,
                "categories": [
                    "Fiction"
                ],
                "imageLinks": {
                    "smallThumbnail": "http://books.google.com/books/content?id=Niwuc1LblAsC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                    "thumbnail": "http://books.google.com/books/content?id=Niwuc1LblAsC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                },
                "language": "en"
            }
        }); */
    }

    getFields(type) {
        if (type === "small") {
            return "items(volumeInfo(title,authors/*,industryIdentifiers,imageLinks/*))";
        }
    }

    PipeFullBook(book) {


        return {
            isbn:
                'industryIdentifiers' in book.volumeInfo ? book.volumeInfo.industryIdentifiers[0].identifier : 0,

            title: book.volumeInfo.title,
            authors: book.volumeInfo.authors,
            publisher: book.volumeInfo.publisher,
            publishedDate: book.volumeInfo.publishedDate,
            description: book.volumeInfo.description,
            pageCount: book.volumeInfo.pageCount,
            categories: book.volumeInfo.categories,
            language: book.volumeInfo.language,
            image:
                book.volumeInfo.imageLinks ?
                    book.volumeInfo.imageLinks.thumbnail : "assets/images/no-cover.jpg"

        };
    }

    PipeSmallBook(book) {

        return {
            isbn:
                book.volumeInfo.industryIdentifiers ? book.volumeInfo.industryIdentifiers[0].identifier : 0,

            title: book.volumeInfo.title,

            authors:
                book.volumeInfo.authors ? book.volumeInfo.authors || [].join(", ") : "Anonim",

            image:
                book.volumeInfo.imageLinks ?
                    book.volumeInfo.imageLinks.smallThumbnail : "assets/images/no-cover.jpg"

        };
    }

    Search(model, query) {
        return this.httpro
            .get(`https://www.googleapis.com/books/v1/volumes?prettyPrint=false&orderBy=newest&q=${query}`)
            .to(model)
            .exec();
    }
}
