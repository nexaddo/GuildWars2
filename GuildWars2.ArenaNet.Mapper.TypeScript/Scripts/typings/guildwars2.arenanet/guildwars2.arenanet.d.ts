declare module GuildWars2.ArenaNet {
    export module API {

        export interface EventDetailsResponse {
            events: { [key: string]: GuildWars2.ArenaNet.Model.EventDetails };
        }

        export interface EventNamesResponse extends Array<GuildWars2.ArenaNet.Model.Event> { }

        export interface EventsResponse {
            events: GuildWars2.ArenaNet.Model.EventState[];
        }

        export interface MapFloorResponse extends GuildWars2.ArenaNet.Model.Floor { }

        export interface MapNamesResponse extends Array<GuildWars2.ArenaNet.Model.Map> { }

        export interface WorldNamesResponse extends Array<GuildWars2.ArenaNet.Model.World> { }

    }

    export module Model {

        export interface Event extends NamedModel<string> { }

        export interface EventDetails {
            name: string;
            level: number;
            map_id: number;
            flags: string[]; /* "group_event", "map_wide" */
            location: Location;
        }

        export interface EventState {
            world_id: number;
            map_id: number;
            event_id: string;
            state: string; /* "Active", "Success", "Fail", "Warmup", "Inactive", "Preparation" */
        }

        export interface Floor {
            texture_dims: number[];
            regions: { [key: string]: FloorRegion };
        }

        export interface FloorMapDetails {
            name: string;
            min_level: number;
            max_level: number;
            default_floor: number;
            map_rect: number[][];
            continent_rect: number[][];
            points_of_interest: PointOfInterest[];
            tasks: Task[];
            skill_challenges: MappedModel[];
            sectors: Sector[];
        }

        export interface FloorRegion {
            name: string;
            label_coord: number[];
            maps: { [key: string]: FloorMapDetails };
        }

        export interface Location {
            type: string; /* "cylinder", "poly", "sphere" */
            center: number[];

            /* cylinder / sphere values */
            radius?: number;
            rotation?: number;

            /* cylinder only values */
            height?: number;

            /* poly only values */
            z_range?: number[];
            points?: number[][];
        }

        export interface Map extends NamedModel<number> { }

        export interface MappedModel {
            coord: number[];
        }

        export interface NamedModel<T> {
            id: T;
            name: string;
        }

        export interface PointOfInterest extends MappedModel {
            poi_id: number;
            name: string;
            type: string; /* "landmark", "unlock", "vista", "waypoint" */
            floor: number;
        }

        export interface Sector extends MappedModel {
            sector_id: number;
            name: string;
            level: number;
        }

        export interface Task extends MappedModel {
            task_id: number;
            objective: string;
            level: number;
        }

        export interface World extends NamedModel<number> { }

    }
}
