import { trigger, animate, style, group, animateChild, query, stagger, transition, state } from '@angular/animations';

export const routerTransitionAnimation = trigger(
    'routerTransition',
    [
        transition('* <=> *', [
            group([
                query(
                    ':enter',
                    [
                        style({ opacity: 0 }),
                        animate('0ms ease-in-out', style({ opacity: 1 })),
                        animateChild()
                    ],
                    { optional: true }
                ),
                query(
                    ':leave',
                    [
                        style({ opacity: 1 }),
                        animate('0ms ease-in-out', style({ opacity: 0 }))
                    ],
                    { optional: true }
                ),
            ])
        ])
    ]
);
